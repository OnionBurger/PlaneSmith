﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace LevelEditor
{
    class Object : ICodeContainer
    {
        private int id;

        private Level level;

        private Definition definition;
        private Point position;

        private Code code;

        public Object(Level Lvl)
        {
            level = Lvl;
            definition = null;
            position = new Point();
            code = new Code(this);
        }

        public Object(Level Lvl, Definition Def)
        {
            level = Lvl;
            definition = Def;
            position = new Point();
            code = new Code(this);
            code.CopyFrom(Def.GetCodeObjAuto());
        }

        public Definition GetDefinition()
        {
            return definition;
        }

        public void SetPosition(Point Pos)
        {
            position.X = Pos.X;
            position.Y = Pos.Y;

            if (level != null) level.Changed = true;
        }

        [Description("The coordinates of this object on the level."),
        Category("General")]
        public Point Position
        {
            get { return position; }
            set
            {
                SetPosition(value);
                if (level != null) level.Changed = true;
                level.Foundation.Form.onObjPositionChanged(this);
            }
        }

        public void SetId(int Id)
        {
            id = Id;
            if (level != null) level.Changed = true;
        }

        [Description("This is the ID by which this application manages this object."),
        Category("General")]
        public int Id
        {
            get { return id; }
        }

        public Code GetCode()
        {
            return code;
        }
        
        public void OnCodeChanged(Code Code)
        {
            if (level != null) level.Changed = true;
        }

        public bool Contains(Point Pnt)
        {
            if (definition == null) return false;

            return Pnt.X >= Position.X &&
                Pnt.X < Position.X + definition.Image.Size.Width &&
                Pnt.Y >= Position.Y &&
                Pnt.Y < Position.Y + definition.Image.Size.Height;
        }

        public void Draw(Graphics G)
        {
            if (definition != null && definition.Image != null) G.DrawImage(definition.Image, Position);
        }

        public override string ToString()
        {
            return "[" + id + "] " + 
                (definition != null ? definition.Name : "??") + 
                " (" + position.X + ", " + position.Y + ")";
        }

        public string ToStringVerbose()
        {
            return ToString() + " (Obj.)";
        }

        public void Save(System.IO.StreamWriter FS)
        {
            FS.WriteLine("" + id);
            FS.WriteLine(definition.Id);
            FS.WriteLine(position.X);
            FS.WriteLine(position.Y);

            code.Save(FS);
        }

        public bool Load(System.IO.StreamReader FS)
        {
            if (!Int32.TryParse(FS.ReadLine(), out id)) return false;

            int defId;
            if (!Int32.TryParse(FS.ReadLine(), out defId)) return false;
            definition = level.Foundation.Dictionary.Get(defId);
            if (definition == null) return false;

            int x;
            if (!Int32.TryParse(FS.ReadLine(), out x)) return false;
            position.X = x;

            int y;
            if (!Int32.TryParse(FS.ReadLine(), out y)) return false;
            position.Y = y;

            if (!code.Load(FS)) return false;

            return true;
        }
    }
}
