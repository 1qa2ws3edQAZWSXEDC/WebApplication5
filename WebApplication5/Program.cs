var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
var users = new List<User>();


app.MapPost("/addUser", (User user) =>
{
    users.Add(user);
    return "Hello!";
});
app.MapGet("/LoginBody", (LoginBody user) =>
{
    var check = users.Find(u => u.Login == user.Login )
});
app.MapGet("/users", () =>
{
    return users;
});
//app.MapPost("/changePassword", (ChangePassword newPass ) =>
//{
  //  var user = users.Find(u => u.Login == newPass.Login && u.Password == newPass.Password);
    //user.Password = newPass.newPassword;
//});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();



public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    
}

public class LoginBody
{
    public int Id { get; set; }
    public string Login { get; set; }
}
public enum Role
{
    Admin, RegularUser, PrivilegedUser, Moderator
}

