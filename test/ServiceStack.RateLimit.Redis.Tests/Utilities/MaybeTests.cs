﻿namespace ServiceStack.RateLimit.Redis.Tests.Utilities
{
    using System;
    using FluentAssertions;
    using Redis.Utilities;
    using Xunit;

    public class MaybeTests
    {
        [Fact]
        public void DefaultCtor_HasValueFalse() => new Maybe<string>().HasValue.Should().BeFalse();

        [Fact]
        public void Ctor_Param_HasValueFalse_IfPassedNull() => new Maybe<string>(null).HasValue.Should().BeFalse();

        [Fact]
        public void Ctor_Param_HasValueTrue_IfPassedValue() => new Maybe<string>("jepsen").HasValue.Should().BeTrue();

        [Fact]
        public void Value_ThrowsInvalidOperation_IfValueNull()
        {
            Action action = () => { var x = new Maybe<string>().Value; };

            action.ShouldThrow<InvalidOperationException>().WithMessage("Nullable object must have a value");
        }

        [Fact]
        public void Value_ReturnsValue()
        {
            var value = "jepsen";
            var maybe = new Maybe<string>(value);

            maybe.Value.Should().Be(value);
        }
    }
}
