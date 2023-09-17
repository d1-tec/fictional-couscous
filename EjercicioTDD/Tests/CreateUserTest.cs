using Domain;

namespace Tests;

[TestClass]
public class CreateUserTest
{
    [TestMethod]
    [ExpectedException(typeof(InvalidUserException))]
    [DataRow("")]
    [DataRow(null)]
    [DataRow("   ")]
    [DataRow("usertest.com")]
    [DataRow("user@test")]
    [DataRow("user@test@test.com")]
    public void AUserWithAnInvalidEmailCannotBeCreated(string email)
    {
        UserController userController = new UserController();

        userController.SignUp(email);
    }

    [TestMethod]
    public void AValidUserGetsCreated()
    {
        UserController userController = new UserController();

        userController.SignUp("user@test.com");

        int amountOfUsers = userController.AmountOfRegisteredUsers();

        Assert.AreEqual(1, amountOfUsers);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidUserException))]
    public void AUserWithARepeatedEmailCannotBeCreated()
    {
        UserController userController = new UserController();
        userController.SignUp("user@test.com");

        userController.SignUp("user@test.com");
    }
}
