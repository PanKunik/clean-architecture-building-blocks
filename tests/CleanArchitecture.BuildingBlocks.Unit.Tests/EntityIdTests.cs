namespace PanKunik.CleanArchitecture.BuildingBlocks.Unit.Tests;

public class EntityIdTests
{
    [Fact]
    public void EntityId_WhenCalledWithNullValue_ShouldThrowArgumentNullExcetpion()
    {
        // Arrange
        var createEntityId = () => new StringId(null);

        // Act && Assert
        Assert.Throws<ArgumentNullException>(createEntityId);
    }

    [Fact]
    public void ToString_WhenCalled_ShouldReturnExpectedString()
    {
        // Arrange
        var cut = new IntId(2);

        // Act
        var result = cut.ToString();

        // Assert
        Assert.Equal("2", result);
    }

    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000001")]
    [InlineData("A0032000-00C0-0080-0000-00F020000101", "A0032000-00C0-0080-0000-00F020000101")]
    public void GetHashCode_WhenCalledForSameValues_ShouldBeEqual(string value, string otherValue)
    {
        // Arrange
        var cut = new ActivityId(Guid.Parse(value));
        var other = new ActivityId(Guid.Parse(otherValue));

        // Act
        var cutHashCode = cut.GetHashCode();
        var otherHashCode = other.GetHashCode();

        // Assert
        Assert.Equal(cutHashCode, otherHashCode);
    }

    [Theory]
    [InlineData("A0032000-00C0-0080-0000-00F020000101", "00000000-0000-0000-0000-000000000001")]
    [InlineData("00000000-0000-0000-0000-000000000001", "A0032000-00C0-0080-0000-00F020000101")]
    public void GetHashCode_WhenCalledForOtherValues_ShouldNotBeEqual(string value, string otherValue)
    {
        // Arrange
        var cut = new ActivityId(Guid.Parse(value));
        var other = new ActivityId(Guid.Parse(otherValue));

        // Act
        var cutHashCode = cut.GetHashCode();
        var otherHashCode = other.GetHashCode();

        // Assert
        Assert.NotEqual(cutHashCode, otherHashCode);
    }

    [Fact]
    public void Equals_WhenOtherIsNotValueObject_ShouldReturnFalse()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var cut = new UserId(guid);
        var otherValue = guid;

        // Act
        var result = cut.Equals(otherValue);

        // Assert
        Assert.False(result);
    }


    [Fact]
    public void Equals_WhenOtherHasSameValue_ShouldReturnTrue()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var cut = new UserId(guid);
        var other = new UserId(guid);
        
        // Act
        var result = cut.Equals(other);
        
        // Assert
        Assert.True(result);
       
    }

    [Fact]
    public void Equals_WhenOtherHasDifferentValue_ShouldReturnFalse()
    {
        // Arrange
        var cut = new UserId(Guid.NewGuid());
        var other =  new UserId(Guid.NewGuid());
        
        // Act
        var result = cut.Equals(other);
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_WhenOtherValueHasSameValueButDifferentType_ShouldReturnFalse()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var cut = new UserId(guid);
        var  other = new ActivityId(guid);
        
        // Act
        var result = cut.Equals(other);
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void EqualOperator_WhenOtherHasSameValue_ShouldReturnTrue()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var cut = new UserId(guid);
        var other = new UserId(guid);
        
        // Act
        var result = cut == other;
        
        // Assert
        Assert.True(result);
       
    }

    [Fact]
    public void EqualOperator_WhenOtherHasDifferentValue_ShouldReturnFalse()
    {
        // Arrange
        var cut = new UserId(Guid.NewGuid());
        var other =  new UserId(Guid.NewGuid());
        
        // Act
        var result = cut == other;
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void EqualOperator_WhenOtherValueHasSameValueButDifferentType_ShouldReturnFalse()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var cut = new UserId(guid);
        var  other = new ActivityId(guid);
        
        // Act
        var result = cut == other;
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void NotEqualOperator_WhenOtherHasSameValue_ShouldReturnFalse()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var cut = new UserId(guid);
        var other = new UserId(guid);
        
        // Act
        var result = cut != other;
        
        // Assert
        Assert.False(result);
       
    }

    [Fact]
    public void NotEqualOperator_WhenOtherHasDifferentValue_ShouldReturnTrue()
    {
        // Arrange
        var cut = new UserId(Guid.NewGuid());
        var other =  new UserId(Guid.NewGuid());
        
        // Act
        var result = cut != other;
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void NotEqualOperator_WhenOtherValueHasSameValueButDifferentType_ShouldReturnTrue()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var cut = new UserId(guid);
        var  other = new ActivityId(guid);
        
        // Act
        var result = cut != other;
        
        // Assert
        Assert.True(result);
    }
    
    private sealed class UserId(Guid value)
        : EntityId<Guid>(value);
    
    private sealed class ActivityId(Guid value)
        : EntityId<Guid>(value);

    private sealed class StringId(string value)
        : EntityId<string>(value);

    private sealed class IntId(int value)
        : EntityId<int>(value);
}