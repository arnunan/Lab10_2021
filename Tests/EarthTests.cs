using NUnit.Framework;
using SaveEarth.MainClasses;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tests
{
    [TestFixture]
    public class EarthTests
    {      
        [Test]
        public void Earth_Should_Died_When_Damage_Is_Equal_EarthHP()
        {
            new Earth(0, 0, 1);
            var a1 = new Earth(0, 0, 1);
            a1.TakeDamage(1);
            a1.isDead.Should().BeTrue();

            var a2 = new Earth(0, 0, 10);
            a2.TakeDamage(10);
            a2.isDead.Should().BeTrue();

            var a3 = new Earth(0, 0, 1000);
            a3.TakeDamage(1000);
            a3.isDead.Should().BeTrue();

            var a4 = new Earth(0, 0, 500);
            a4.TakeDamage(500);
            a4.isDead.Should().BeTrue();

            var a5 = new Earth(0, 0, 1000000);
            a5.TakeDamage(1000000);
            a5.isDead.Should().BeTrue();
        }


        [Test]
        public void Earth_Should_Died_When_Damage_Is_Bigger_Then_EarthHP()
        {
            var a1 = new Earth(0, 0, 1);
            a1.TakeDamage(110000);
            a1.isDead.Should().BeTrue();

            var a2 = new Earth(0, 0, 10);
            a2.TakeDamage(10000);
            a2.isDead.Should().BeTrue();

            var a3 = new Earth(0, 0, 1000);
            a3.TakeDamage(10000);
            a3.isDead.Should().BeTrue();

            var a4 = new Earth(0, 0, 500);
            a4.TakeDamage(1000);
            a4.isDead.Should().BeTrue();

            var a5 = new Earth(0, 0, 1000000);
            a5.TakeDamage(11000000);
            a5.isDead.Should().BeTrue();         
        }

        [Test]
        public void Earth_Shouldnt_Died_When_Damage_Is_Less_Then_EarthHP()
        {
            var a1  = new Earth(0, 0, 2);
            a1.TakeDamage(1);
            a1.isDead.Should().BeFalse();

            var a2 = new Earth(0, 0, 10);
            a2.TakeDamage(7);
            a2.isDead.Should().BeFalse();

            var a3 = new Earth(0, 0, 1000);
            a3.TakeDamage(100);
            a3.isDead.Should().BeFalse();

            var a4 = new Earth(0, 0, 500);
            a4.TakeDamage(50);
            a4.isDead.Should().BeFalse();

            var a5 = new Earth(0, 0, 1000000);
            a5.TakeDamage(1000);
            a5.isDead.Should().BeFalse();
        }
    }
}
