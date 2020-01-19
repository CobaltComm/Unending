using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Unending
{
    public class UnendingWorld : ModWorld
    {
        #region Mayhem mode!
        public static bool MayhemMode; //The main event!
        #endregion

        public override void Initialize()
        {
            #region Mayhem
            MayhemMode = false;
            #endregion
        }

        public override TagCompound Save()
        {
            List<string> mayhemVariables = new List<string>();
            if (MayhemMode) mayhemVariables.Add("mayhem");

            return new TagCompound
            {
                {"mayhemVariables", mayhemVariables}
            };
        }

        public override void Load(TagCompound tag)
        {
            IList<string> mayhemVariables = tag.GetList<string>("mayhemVariables");
            MayhemMode = mayhemVariables.Contains("mayhem");
        }
    }
}