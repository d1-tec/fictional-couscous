namespace Domain;

public class UserController
{
    private List<string> users;

    public UserController()
    {
        this.users = new List<string>();
    }

    public void SignUp(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !IsEmailValid(email) || this.users.Contains(email))
            throw new InvalidUserException();

        this.users.Add(email);
    }

    public int AmountOfRegisteredUsers() => this.users.Count;

    private bool IsEmailValid(string email)
    {
        if (email.Count(x => x == '@') != 1) return false;

        string[] emailParts = email.Split("@");

        if (!emailParts[1].Contains(".com")) return false;

        return true;
    }
}

