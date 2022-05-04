using QFramework;

namespace MagicCricle_Isaac
{
    public class MagicCricle_Isaac_Context : Architecture<MagicCricle_Isaac_Context>
    {
        protected override void Init()
        {
            RegisterSystem(new UISystem());
            RegisterModel(new MagicCricleModel());
            RegisterModel(new AvailableSkillsModel());
        }
    }
}