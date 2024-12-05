namespace Emne3.assignments.Assignment328A;

public class Water
{
    public WaterState State { get; private set; }
    public double Temperature { get; private set; }
    public int Amount { get; }
    public double ProportionFirstState { get; private set; }

    public Water(int amount, int temperature, double? ratio = null)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be greater than 0", nameof(amount));
        
        State = DetermineState(temperature, ratio); 
        Temperature = temperature;
        Amount = amount;
        ProportionFirstState = ratio ?? 1.0;
    }

    public void AddEnergy(int joules)
    {
        while (joules > 0)
        {
            var neededJoulesToNextPhaseChange = JoulesRequiredToNextPhaseChange();
            if (neededJoulesToNextPhaseChange == 0)
            {
                joules = ProcessPhaseChangeAndReturnJoulesLeft(joules);
            }
            else if (joules < neededJoulesToNextPhaseChange)
            {
                Temperature += (double)joules / Amount;
                joules = 0;
            }
            else
            {
                Temperature += neededJoulesToNextPhaseChange/Amount;
                joules -= neededJoulesToNextPhaseChange;
                if (joules > 0) State = NextState();
            }
        }
    }

    private int ProcessPhaseChangeAndReturnJoulesLeft(int joules)
    {
        if (State == WaterState.IceAndFluid) return PhaseChange(joules, 80);
        return PhaseChange(joules, 600);
    }

    private int PhaseChange(int joules, int joulesNeededPrGram)
    {
        var gramsOfFirstState = Amount * ProportionFirstState;
        var joulesToTransformFirstState = joulesNeededPrGram * gramsOfFirstState;
        while (ProportionFirstState > 0.0) 
        {
            if (joules < joulesNeededPrGram)
            {
                if (joules == 0) return 0;
                var portionOfOneMelted = 1/(double)joulesNeededPrGram*joules;
                ProportionFirstState -= portionOfOneMelted / Amount;
                return 0;
            }
            if (joules >= joulesToTransformFirstState)
            {
                joules -= (int)double.Floor(joulesToTransformFirstState);
                break;
            }
            
            joules -= joulesNeededPrGram;
            ProportionFirstState -= (double)1 / Amount;
        }

        State = NextState();
        ProportionFirstState = 1.0;
        return joules;
    }

    private WaterState NextState()
    {
        return State switch
        {
            WaterState.Ice => WaterState.IceAndFluid,
            WaterState.IceAndFluid => WaterState.Fluid,
            WaterState.Fluid => WaterState.FluidAndGas,
            WaterState.FluidAndGas => WaterState.Gas,
            WaterState.Gas => WaterState.Gas,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private int JoulesRequiredToNextPhaseChange()
    {
        var temperatureDifferance = (NextPhaseChangeTemp() - (int)double.Round(Temperature));
        return temperatureDifferance * Amount;
    }

    private int NextPhaseChangeTemp()
    {
        return State switch
        {
            WaterState.Ice => 0,
            WaterState.IceAndFluid => 0,
            WaterState.Fluid => 100,
            WaterState.FluidAndGas => 100,
            WaterState.Gas => 6000,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    private static WaterState DetermineState(double temperature, double? ratio)
    {
        return temperature switch
        {
            < 0 => WaterState.Ice,
            0 => MixedStateMaybe(true, ratio),
            100 => MixedStateMaybe(false, ratio),
            > 100 => WaterState.Gas,
            _ => WaterState.Fluid
        };
    }
    
    private static WaterState MixedStateMaybe(bool isZero, double? ratio)
    {
        if (ratio == null)
        {
            throw new ArgumentException("When temperature is 0 or 100, you must provide a value for proportion");
            
        }
        if (ratio is 1.0)
        {
            return isZero ? WaterState.Ice : WaterState.Fluid;
        }

        return isZero ? WaterState.IceAndFluid : WaterState.FluidAndGas;
    }
    
}