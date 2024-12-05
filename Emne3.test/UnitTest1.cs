namespace Emne3.tests;
using NUnit.Framework;
using assignments.Assignment328A;
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test01WaterAt20Degrees()
    {
        var water = new Water(50, 20);
        Assert.That(WaterState.Fluid, Is.EqualTo(water.State));
        Assert.That(20, Is.EqualTo(water.Temperature));
        Assert.That(50, Is.EqualTo(water.Amount));
    }
    
    [Test]
    public void Test02WaterAtMinus20Degrees()
    {
        var water = new Water(50, -20);
        Assert.That(water.State, Is.EqualTo(WaterState.Ice));
        Assert.That(water.Temperature, Is.EqualTo(-20));
    }
    
    [Test]
    // Tester om tilstanden blir gass ved 120 grader
    public void Test03WaterAt120Degrees()
    {
        var water = new Water(50, 120);
        Assert.That(water.State, Is.EqualTo(WaterState.Gas));
        Assert.That(water.Temperature,Is.EqualTo(120));
    }
    
    [Test]
    // Ved 0 og 100 grader må vi angi en frivillig parameter til constructoren som angir hvor stor del 
    // som er i den første fasen (altså is ved blanding av is og flytende - og flytende ved blanding 
    // av flytende og gass). Denne testen sjekker at vi får exception om dette ikke er angitt og temperaturen
    // er 100 grader.
    public void Test04WaterAt100DegreesWithoutProportion()
    {
        var exception = Assert.Throws<ArgumentException>(() =>
        {
            new Water(50, 100);
        });

        Assert.That(exception?.Message, Is.EqualTo("When temperature is 0 or 100, you must provide a value for proportion"));
    }
    
    [Test]
    // Sjekker at vi får miks av flytende og gass, med 30% av det første
    public void Test05WaterAt100Degrees()
    {
        var water = new Water(50, 100, 0.3);
        Assert.That(WaterState.FluidAndGas, Is.EqualTo(water.State));
        Assert.That(water.Temperature, Is.EqualTo(100));
        Assert.That(water.ProportionFirstState, Is.EqualTo(0.3));
    }
   
    [Test]
    public void Test06WaterAt100Degrees()
    {
        var water = new Water(50, 100, 0.3);
        Assert.That(water.State, Is.EqualTo(WaterState.FluidAndGas));
        Assert.That(water.Temperature, Is.EqualTo(100));
    }
    
    [Test]
    public void Test07WaterAt100Degrees()
    {
        var water = new Water(50, 100, 0.3);
        Assert.That(water.State, Is.EqualTo(WaterState.FluidAndGas));
        Assert.That(water.Temperature, Is.EqualTo(100));
    }
    
    [Test]
    // Tester at når vi tilfører energi, så stiger temperaturen med riktig antall grader
    public void Test08AddEnergy1()
    {
        var water = new Water(4, 10);
        water.AddEnergy(10);
        Assert.That(water.Temperature, Is.EqualTo(12.5));
    }
    
    [Test]        
    public void Test09AddEnergy2()
    {
        var water = new Water(4, -10);
        water.AddEnergy(10);
        Assert.That(water.Temperature, Is.EqualTo(-7.5));
    }
  
     [Test]
     // Tester at vann under 0 grader både varmes til 0 og så smeltes om vi tilfører nok energi.
     // Tester også at temperaturen stopper på 0 grader om vi ikke har nok energi til å smelte alt.
     public void Test10AddEnergy3()
     {
         var water = new Water(4, -10);
         water.AddEnergy(168);
         Assert.That(water.Temperature, Is.EqualTo(0));
         Assert.That(water.State, Is.EqualTo(WaterState.IceAndFluid));
         Assert.That(water.ProportionFirstState, Is.EqualTo(0.6));
     }

     [Test]
     public void Test11AddEnergy4()
     {
         var water = new Water(4, -10);
         water.AddEnergy(360);
         Assert.That(water.Temperature, Is.EqualTo(0));
         Assert.That(water.State, Is.EqualTo(WaterState.Fluid));
     }

    [Test]
    // Tester at overflødig energi etter smelting går til oppvarming med riktig antall grader.
    public void Test12AddEnergy5()
    {
        var water = new Water(4, -10);
        water.AddEnergy(400);
        Assert.That(water.Temperature, Is.EqualTo(10));
        Assert.That(water.State, Is.EqualTo(WaterState.Fluid));
    }

     [Test]
     public void Test13FluidToGasA()
     {
         var water = new Water(10, 70);
         water.AddEnergy(900);
         Assert.That(water.Temperature, Is.EqualTo(100));
         Assert.That(water.State, Is.EqualTo(WaterState.FluidAndGas));
         Assert.That(water.ProportionFirstState, Is.EqualTo(0.9));
     }

     [Test]
     public void Test14FluidToGasB()
     {
         var water = new Water(10, 70);
         water.AddEnergy(6300);
         Assert.That(water.Temperature, Is.EqualTo(100));
         Assert.That(water.State, Is.EqualTo(WaterState.Gas));
     }

     [Test]
     public void Test14FluidToGasC()
     {
         var water = new Water(10, 70);
         water.AddEnergy(6400);
         Assert.That(water.Temperature, Is.EqualTo(110));
         Assert.That(water.State, Is.EqualTo(WaterState.Gas));
     }    
}