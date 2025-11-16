# 🔄 MIGRATION GUIDE: DataAccessBase → BaseRepository

## 📋 TÓM TẮT

**DataAccessBase** đã được đánh dấu là **DEPRECATED** và thay thế bằng **BaseRepository pattern**.

## ✅ TẠI SAO CẦN MIGRATE?

### ❌ Vấn đề với DataAccessBase (Old):

- **Static methods** - Khó test, khó mock
- **Trả về DataTable** - Cần mapping thủ công
- **Không có transaction support tốt**
- **Duplicate code** - Mỗi repository tự viết logic riêng
- **Khó maintain** - Code rải rác khắp nơi

### ✅ Lợi ích của BaseRepository (New):

- **OOP-based** - Kế thừa, dễ extend
- **Generic methods** - Tự động mapping với SqlDataReader
- **Built-in transaction** - ExecuteTransaction method
- **Type-safe helpers** - GetString, GetInt, GetDecimal...
- **Centralized logic** - Tất cả database access ở một chỗ
- **Better error handling** - Tích hợp Logger và ExceptionHandler
- **Async support** - ExecuteQueryAsync, ExecuteNonQueryAsync

---

## 🏗️ KIẾN TRÚC MỚI

```
DataAccess/
├── DatabaseConfig.cs        ← Quản lý connection string (NEW)
├── DataAccessBase.cs        ← [DEPRECATED] Legacy code
└── (removed methods)

Repositories/
├── BaseRepository.cs        ← Base class cho tất cả repositories (NEW)
└── Implementations/
    ├── SanPhamRepository.cs     ← Đã migrate ✅
    ├── HoaDonBanRepository.cs   ← Đã migrate ✅
    └── [YourRepository].cs      ← Cần migrate
```

---

## 📝 HƯỚNG DẪN MIGRATE

### BƯỚC 1: Kế thừa BaseRepository

**Trước (Old):**

```csharp
public class MyRepository : IMyRepository
{
    public List<MyModel> GetAll()
    {
        var list = new List<MyModel>();
        var dt = DataAccessBase.ExecuteQuery("SELECT * FROM MyTable");
        foreach (DataRow r in dt.Rows)
        {
            list.Add(Map(r));
        }
        return list;
    }

    private MyModel Map(DataRow r)
    {
        return new MyModel
        {
            Id = r["Id"]?.ToString() ?? "",
            Name = r["Name"]?.ToString() ?? "",
            Price = r.Field<decimal?>("Price") ?? 0m
        };
    }
}
```

**Sau (New):**

```csharp
public class MyRepository : BaseRepository, IMyRepository
{
    public List<MyModel> GetAll()
    {
        string query = "SELECT * FROM MyTable";
        return ExecuteQuery(query, null, MapFromReader);
    }

    private MyModel MapFromReader(SqlDataReader reader)
    {
        return new MyModel
        {
            Id = GetString(reader, "Id"),
            Name = GetString(reader, "Name"),
            Price = GetDecimal(reader, "Price")
        };
    }
}
```

---

### BƯỚC 2: Sử dụng Helper Methods

BaseRepository cung cấp các helper type-safe:

```csharp
// Thay vì:
var id = r["Id"]?.ToString() ?? "";
var price = r.Field<decimal?>("Price") ?? 0m;
var isActive = r.Field<bool?>("IsActive") ?? false;
var createdDate = r.Field<DateTime?>("CreatedDate");

// Dùng:
var id = GetString(reader, "Id");
var price = GetDecimal(reader, "Price");
var isActive = GetBool(reader, "IsActive");
var createdDate = GetDateTime(reader, "CreatedDate");
```

---

### BƯỚC 3: Query với Parameters

**Trước:**

```csharp
public MyModel? GetById(string id)
{
    var dt = DataAccessBase.ExecuteQuery(
        "SELECT * FROM MyTable WHERE Id = @Id",
        new SqlParameter("@Id", id)
    );
    if (dt.Rows.Count == 0) return null;
    return Map(dt.Rows[0]);
}
```

**Sau:**

```csharp
public MyModel? GetById(string id)
{
    string query = "SELECT * FROM MyTable WHERE Id = @Id";
    var parameters = new[] { CreateParameter("@Id", id) };
    var results = ExecuteQuery(query, parameters, MapFromReader);
    return results.Count > 0 ? results[0] : null;
}
```

---

### BƯỚC 4: INSERT/UPDATE/DELETE

**Trước:**

```csharp
public void Insert(MyModel model)
{
    DataAccessBase.ExecuteNonQuery(
        "INSERT INTO MyTable(Id, Name, Price) VALUES(@Id, @Name, @Price)",
        new SqlParameter("@Id", model.Id),
        new SqlParameter("@Name", model.Name),
        new SqlParameter("@Price", model.Price)
    );
}
```

**Sau:**

```csharp
public void Insert(MyModel model)
{
    string query = "INSERT INTO MyTable(Id, Name, Price) VALUES(@Id, @Name, @Price)";
    var parameters = new[]
    {
        CreateParameter("@Id", model.Id),
        CreateParameter("@Name", model.Name),
        CreateParameter("@Price", model.Price)
    };
    ExecuteNonQuery(query, parameters);
}
```

---

### BƯỚC 5: Transaction

**Trước:**

```csharp
public void InsertWithDetails(MyModel model, List<Detail> details)
{
    var connString = DataAccessBase.GetConnectionString();
    using var conn = new SqlConnection(connString);
    conn.Open();
    using var tran = conn.BeginTransaction();
    try
    {
        using var cmd1 = conn.CreateCommand();
        cmd1.Transaction = tran;
        cmd1.CommandText = "INSERT INTO MyTable...";
        cmd1.ExecuteNonQuery();

        foreach (var detail in details)
        {
            using var cmd2 = conn.CreateCommand();
            cmd2.Transaction = tran;
            cmd2.CommandText = "INSERT INTO Details...";
            cmd2.ExecuteNonQuery();
        }

        tran.Commit();
    }
    catch
    {
        try { tran.Rollback(); } catch { }
        throw;
    }
}
```

**Sau:**

```csharp
public void InsertWithDetails(MyModel model, List<Detail> details)
{
    ExecuteTransaction((conn, tran) =>
    {
        // Insert main record
        string queryMain = "INSERT INTO MyTable...";
        using (var cmd = new SqlCommand(queryMain, conn, tran))
        {
            cmd.Parameters.Add(CreateParameter("@Id", model.Id));
            cmd.ExecuteNonQuery();
        }

        // Insert details
        string queryDetail = "INSERT INTO Details...";
        foreach (var detail in details)
        {
            using var cmd = new SqlCommand(queryDetail, conn, tran);
            cmd.Parameters.Add(CreateParameter("@DetailId", detail.Id));
            cmd.ExecuteNonQuery();
        }

        return true; // Success
    });
}
```

---

## 🔍 CHECKLIST MIGRATE

- [ ] Kế thừa `BaseRepository` thay vì dùng static methods
- [ ] Thay đổi `Map(DataRow)` thành `MapFromReader(SqlDataReader)`
- [ ] Dùng `ExecuteQuery<T>()` thay vì `DataAccessBase.ExecuteQuery()`
- [ ] Dùng helper methods: `GetString()`, `GetInt()`, `GetDecimal()`...
- [ ] Dùng `CreateParameter()` để tạo SqlParameter
- [ ] Dùng `ExecuteNonQuery()` thay vì `DataAccessBase.ExecuteNonQuery()`
- [ ] Dùng `ExecuteTransaction()` cho operations cần transaction
- [ ] Remove `using System.Data;` và `using DataRow` nếu không cần
- [ ] Test kỹ sau khi migrate

---

## 📊 SO SÁNH

| Feature            | DataAccessBase (Old) | BaseRepository (New)      |
| ------------------ | -------------------- | ------------------------- |
| **Architecture**   | Static methods       | OOP inheritance           |
| **Return Type**    | DataTable            | List<T>                   |
| **Mapping**        | Manual (DataRow)     | Automatic (SqlDataReader) |
| **Type Safety**    | ❌ Weak              | ✅ Strong                 |
| **Helper Methods** | ❌ None              | ✅ GetString, GetInt...   |
| **Transaction**    | ⚠️ Manual            | ✅ Built-in               |
| **Async Support**  | ❌ No                | ✅ Yes                    |
| **Testability**    | ❌ Hard              | ✅ Easy                   |
| **Error Handling** | ⚠️ Basic             | ✅ Comprehensive          |

---

## ⚠️ BREAKING CHANGES

### 1. Không còn trả về DataTable

```csharp
// ❌ OLD
DataTable dt = DataAccessBase.ExecuteQuery("SELECT...");

// ✅ NEW
List<MyModel> list = ExecuteQuery("SELECT...", null, MapFromReader);
```

### 2. Không còn dùng DataRow

```csharp
// ❌ OLD
private MyModel Map(DataRow r) { ... }

// ✅ NEW
private MyModel MapFromReader(SqlDataReader reader) { ... }
```

### 3. Transaction pattern khác

```csharp
// ❌ OLD
using var conn = new SqlConnection(...);
using var tran = conn.BeginTransaction();

// ✅ NEW
ExecuteTransaction((conn, tran) => { ... });
```

---

## 🚀 MIGRATION PRIORITIES

### Priority 1 - CRITICAL (Migrate ngay):

- [ ] Repositories đang được sử dụng nhiều trong Dev4
- [ ] Repositories có transaction logic phức tạp

### Priority 2 - HIGH:

- [ ] Repositories trong module chính (Sản phẩm, Hóa đơn, Khách hàng...)
- [ ] Repositories có nhiều queries

### Priority 3 - MEDIUM:

- [ ] Repositories ít dùng
- [ ] Repositories đơn giản (CRUD cơ bản)

### Priority 4 - LOW:

- [ ] Legacy code ít thay đổi
- [ ] Code sắp refactor hoàn toàn

---

## 📞 HỖ TRỢ

### Còn DataAccessBase ở đâu?

Check với grep:

```bash
grep -r "DataAccessBase" --include="*.cs"
```

Hiện tại còn 2 file:

- `PosService.cs:169` - ⚠️ Cần migrate
- `HoaDonBanEditForm.cs:380` - ⚠️ Cần migrate

### Code examples

Tham khảo:

- ✅ `SanPhamRepository.cs` - Đã migrate hoàn chỉnh
- ✅ `HoaDonBanRepository.cs` - Đã migrate với transaction

---

**Last updated:** 2024-11-10  
**Status:** DataAccessBase is DEPRECATED, use BaseRepository
