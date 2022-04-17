﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVComboPlus.Combos.WHM
{
    internal class WHMSingleHealFeature : WHMCombo
    {
        public override string ComboFancyName => "白魔单奶";

        public override string Description => "替换治疗为白魔的单奶技能。";

        protected internal override uint[] ActionIDs => new uint[] {Actions.Cure.ActionID};

        protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
        {
            uint act;

            //有人搞超火！这很刺激！
            if(UseBenediction() && Actions.Benediction.TryUseAction(level, out act, mustUse:true)) return act;



            if (IsMoving)
            {
                //再生
                if (Actions.Regen.TryUseAction(level, out act)) return act;


                //安慰之心
                if (Actions.AfflatusSolace.TryUseAction(level, out act)) return act;
            }

            //如果现在可以增加能力技
            if (CanAddAbility(level, out act)) return act;

            //安慰之心
            if (Actions.AfflatusSolace.TryUseAction(level, out act)) return act;

            //再生
            if (Actions.Regen.TryUseAction(level, out act)) return act;

            //救疗
            if (Actions.Cure2.TryUseAction(level, out act)) return act;

            //治疗
            if (Actions.Cure.TryUseAction(level, out act)) return act;

            return 0;
        }
    }
}