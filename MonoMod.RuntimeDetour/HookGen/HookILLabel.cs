﻿using System.Collections.Generic;
using System.Linq;
using Mono.Cecil.Cil;

namespace MonoMod.RuntimeDetour.HookGen {
    public sealed class HookILLabel {

        private readonly HookIL HookIL;
        public Instruction Target;
        
        public IEnumerable<HookILCursor> Branches
            => HookIL.Instrs.Where(i => i.Operand == this).Select(i => new HookILCursor(HookIL, i));

        internal HookILLabel(HookIL hookil) {
            HookIL = hookil;
            HookIL._Labels.Add(this);
        }

        internal HookILLabel(HookIL hookil, Instruction target) : this(hookil) {
            Target = target;
        }
    }
}
