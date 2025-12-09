using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using OrderFlowClase.API.Identity.Services;

namespace OrderFlowClase.Api.Identity.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<UserManager<IdentityUser>> _mockUserManager;
        private Mock<ILogger<UserService>> _mockLogger;
        private UserService _userService;

        [SetUp]
        public void Setup()
        {
            // Mock UserManager
            var userStoreMock = new Mock<IUserStore<IdentityUser>>();
            _mockUserManager = new Mock<UserManager<IdentityUser>>(
                userStoreMock.Object, null!, null!, null!, null!, null!, null!, null!, null!);

            // Mock Logger
            _mockLogger = new Mock<ILogger<UserService>>();

            // Create UserService with mocked dependencies
            _userService = new UserService(
                _mockUserManager.Object,
                _mockLogger.Object
            );
        }

        #region ChangePasswordAsync Tests

        [Test]
        public async Task ChangePasswordAsync_WithValidCredentials_ShouldReturnTrue()
        {
            // Arrange
            var userId = "test-user-id";
            var currentPassword = "OldPassword@123";
            var newPassword = "NewPassword@456";
            var user = new IdentityUser
            {
                Id = userId,
                UserName = "testuser",
                Email = "test@example.com"
            };

            _mockUserManager.Setup(x => x.FindByIdAsync(userId))
                .ReturnsAsync(user);

            _mockUserManager.Setup(x => x.ChangePasswordAsync(user, currentPassword, newPassword))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _userService.ChangePasswordAsync(userId, currentPassword, newPassword);

            // Assert
            Assert.That(result, Is.True);
            _mockUserManager.Verify(x => x.FindByIdAsync(userId), Times.Once);
            _mockUserManager.Verify(x => x.ChangePasswordAsync(user, currentPassword, newPassword), Times.Once);
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Password changed successfully")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
        }

        [Test]
        public async Task ChangePasswordAsync_WithNonExistentUser_ShouldReturnFalse()
        {
            // Arrange
            var userId = "non-existent-user-id";
            var currentPassword = "OldPassword@123";
            var newPassword = "NewPassword@456";

            _mockUserManager.Setup(x => x.FindByIdAsync(userId))
                .ReturnsAsync((IdentityUser)null!);

            // Act
            var result = await _userService.ChangePasswordAsync(userId, currentPassword, newPassword);

            // Assert
            Assert.That(result, Is.False);
            _mockUserManager.Verify(x => x.FindByIdAsync(userId), Times.Once);
            _mockUserManager.Verify(x => x.ChangePasswordAsync(It.IsAny<IdentityUser>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Warning,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("not found")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
        }

        [Test]
        public async Task ChangePasswordAsync_WithIncorrectCurrentPassword_ShouldReturnFalse()
        {
            // Arrange
            var userId = "test-user-id";
            var currentPassword = "WrongPassword@123";
            var newPassword = "NewPassword@456";
            var user = new IdentityUser
            {
                Id = userId,
                UserName = "testuser",
                Email = "test@example.com"
            };

            var identityError = new IdentityError
            {
                Code = "PasswordMismatch",
                Description = "Incorrect password."
            };

            _mockUserManager.Setup(x => x.FindByIdAsync(userId))
                .ReturnsAsync(user);

            _mockUserManager.Setup(x => x.ChangePasswordAsync(user, currentPassword, newPassword))
                .ReturnsAsync(IdentityResult.Failed(identityError));

            // Act
            var result = await _userService.ChangePasswordAsync(userId, currentPassword, newPassword);

            // Assert
            Assert.That(result, Is.False);
            _mockUserManager.Verify(x => x.FindByIdAsync(userId), Times.Once);
            _mockUserManager.Verify(x => x.ChangePasswordAsync(user, currentPassword, newPassword), Times.Once);
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Warning,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Error changing password")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
        }

        [Test]
        public async Task ChangePasswordAsync_WithWeakNewPassword_ShouldReturnFalse()
        {
            // Arrange
            var userId = "test-user-id";
            var currentPassword = "OldPassword@123";
            var newPassword = "weak";
            var user = new IdentityUser
            {
                Id = userId,
                UserName = "testuser",
                Email = "test@example.com"
            };

            var identityError = new IdentityError
            {
                Code = "PasswordTooShort",
                Description = "Passwords must be at least 8 characters."
            };

            _mockUserManager.Setup(x => x.FindByIdAsync(userId))
                .ReturnsAsync(user);

            _mockUserManager.Setup(x => x.ChangePasswordAsync(user, currentPassword, newPassword))
                .ReturnsAsync(IdentityResult.Failed(identityError));

            // Act
            var result = await _userService.ChangePasswordAsync(userId, currentPassword, newPassword);

            // Assert
            Assert.That(result, Is.False);
            _mockUserManager.Verify(x => x.ChangePasswordAsync(user, currentPassword, newPassword), Times.Once);
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Warning,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Error changing password")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
        }

        [Test]
        public async Task ChangePasswordAsync_WithMultipleErrors_ShouldLogAllErrors()
        {
            // Arrange
            var userId = "test-user-id";
            var currentPassword = "OldPassword@123";
            var newPassword = "weak";
            var user = new IdentityUser
            {
                Id = userId,
                UserName = "testuser",
                Email = "test@example.com"
            };

            var identityErrors = new[]
            {
                new IdentityError { Code = "PasswordTooShort", Description = "Passwords must be at least 8 characters." },
                new IdentityError { Code = "PasswordRequiresDigit", Description = "Passwords must have at least one digit ('0'-'9')." },
                new IdentityError { Code = "PasswordRequiresUpper", Description = "Passwords must have at least one uppercase ('A'-'Z')." }
            };

            _mockUserManager.Setup(x => x.FindByIdAsync(userId))
                .ReturnsAsync(user);

            _mockUserManager.Setup(x => x.ChangePasswordAsync(user, currentPassword, newPassword))
                .ReturnsAsync(IdentityResult.Failed(identityErrors));

            // Act
            var result = await _userService.ChangePasswordAsync(userId, currentPassword, newPassword);

            // Assert
            Assert.That(result, Is.False);
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Warning,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Error changing password")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Exactly(3));
        }

        [Test]
        public async Task ChangePasswordAsync_ShouldFindUserBeforeChangingPassword()
        {
            // Arrange
            var userId = "test-user-id";
            var currentPassword = "OldPassword@123";
            var newPassword = "NewPassword@456";
            var user = new IdentityUser
            {
                Id = userId,
                UserName = "testuser",
                Email = "test@example.com"
            };

            _mockUserManager.Setup(x => x.FindByIdAsync(userId))
                .ReturnsAsync(user);

            _mockUserManager.Setup(x => x.ChangePasswordAsync(user, currentPassword, newPassword))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            await _userService.ChangePasswordAsync(userId, currentPassword, newPassword);

            // Assert - Verify the sequence of operations
            _mockUserManager.Verify(x => x.FindByIdAsync(userId), Times.Once);
            _mockUserManager.Verify(x => x.ChangePasswordAsync(user, currentPassword, newPassword), Times.Once);
        }

        [Test]
        public async Task ChangePasswordAsync_WhenSuccessful_ShouldLogInformation()
        {
            // Arrange
            var userId = "test-user-id";
            var currentPassword = "OldPassword@123";
            var newPassword = "NewPassword@456";
            var user = new IdentityUser
            {
                Id = userId,
                UserName = "testuser",
                Email = "test@example.com"
            };

            _mockUserManager.Setup(x => x.FindByIdAsync(userId))
                .ReturnsAsync(user);

            _mockUserManager.Setup(x => x.ChangePasswordAsync(user, currentPassword, newPassword))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            await _userService.ChangePasswordAsync(userId, currentPassword, newPassword);

            // Assert
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Password changed successfully") && v.ToString()!.Contains(userId)),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
        }

        [Test]
        public async Task ChangePasswordAsync_WhenUserNotFound_ShouldLogWarningWithUserId()
        {
            // Arrange
            var userId = "non-existent-user-id";
            var currentPassword = "OldPassword@123";
            var newPassword = "NewPassword@456";

            _mockUserManager.Setup(x => x.FindByIdAsync(userId))
                .ReturnsAsync((IdentityUser)null!);

            // Act
            await _userService.ChangePasswordAsync(userId, currentPassword, newPassword);

            // Assert
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Warning,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains(userId) && v.ToString()!.Contains("not found")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
        }

        [Test]
        public async Task ChangePasswordAsync_WhenPasswordChangeFails_ShouldLogWarningForEachError()
        {
            // Arrange
            var userId = "test-user-id";
            var currentPassword = "OldPassword@123";
            var newPassword = "NewPassword@456";
            var user = new IdentityUser
            {
                Id = userId,
                UserName = "testuser",
                Email = "test@example.com"
            };

            var identityError = new IdentityError
            {
                Code = "PasswordMismatch",
                Description = "Incorrect password."
            };

            _mockUserManager.Setup(x => x.FindByIdAsync(userId))
                .ReturnsAsync(user);

            _mockUserManager.Setup(x => x.ChangePasswordAsync(user, currentPassword, newPassword))
                .ReturnsAsync(IdentityResult.Failed(identityError));

            // Act
            await _userService.ChangePasswordAsync(userId, currentPassword, newPassword);

            // Assert
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Warning,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains(userId) &&
                                                  v.ToString()!.Contains("Error changing password") &&
                                                  v.ToString()!.Contains("Incorrect password")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
        }

        #endregion
    }
}
