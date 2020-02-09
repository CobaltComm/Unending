using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Generation;

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
            # region Mayhem stuff
            List<string> mayhemVariables = new List<string>();
            if (MayhemMode) mayhemVariables.Add("mayhem");

            return new TagCompound
            {
                {"mayhemVariables", mayhemVariables}
            };
            #endregion
        }

        public override void Load(TagCompound tag)
        {
            #region Mayhem Stuff
            IList<string> mayhemVariables = tag.GetList<string>("mayhemVariables");
            MayhemMode = mayhemVariables.Contains("mayhem");
            #endregion
        }
    }
}