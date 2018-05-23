public class PickedUpItemReaction : DelayedReaction
{
    public Item item;


    private ToolBelt belt;


    protected override void SpecificInit()
    {
        belt = FindObjectOfType<ToolBelt>();
    }


    protected override void ImmediateReaction()
    {
        belt.AddItem(item);
    }
}
