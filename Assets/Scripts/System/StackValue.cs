
public class StackValue
{
    public int stack;
    public bool activate;
    public float defaultValue;
    public int maxStack;
    public float amountPerStack;


    public float result { get {return stack * amountPerStack + defaultValue; } }
    public static implicit operator float(StackValue sv)
    {
        return sv.result;
    }


    public void ResetStack()
    {
        stack = 0;
    }

    public void ReduceStack(int amount = 1)
    {
        if(!activate)
            return;
        stack -= amount;
        if(stack < 0)
            stack = 0;
    }

    public void AddStack(int amount = 1)
    {
        if (!activate)
            return;
        stack += amount;
        if(stack > maxStack)
            stack = maxStack;
    }

    public StackValue(int maxStack, float amountPerStack, float defaultValue = 0)
    {
        this.maxStack = maxStack;
        this.amountPerStack = amountPerStack;
        this.defaultValue = defaultValue;
    }
}
