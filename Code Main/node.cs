using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using simulation2;

namespace simulation02
{
    public class Node : Button
    {
        static Random _rand;

        public static Node Instance;
        public static Node GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Node();
            }
            return Instance;
        }
        public Node()
        {
            Height = 15;
            Width = 15;
            index = 0;
            Range = Node_Range;
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (Parent == null)
                return;

            if (_rand == null)
                _rand = new Random();

            Left = _rand.Next(Parent.Width - Width);
            Top = _rand.Next(Parent.Height - Height);
        }
        //protected override void OnPaint(PaintEventArgs pevent)
        //{
        //    GraphicsPath g = new GraphicsPath();
        //    g.AddEllipse(0, 0, Width, Height);
        //    this.Region = new System.Drawing.Region(g);
        //    base.OnPaint(pevent);

        //}
        public int index;
        public int Range { get; set; }
        public int Index
        {
            get { return index; }
            set
            {
                index = value;
                Text = string.Format("{0} {1:00}", this.GetType().Name.Substring(0, 2), index);
            }
        }
        public string text_name;

        public String Text_Name
        {
            get { return text_name; }
            set
            {
                text_name = string.Format("{0} {1:00}", this.GetType().Name.Substring(0, 2), index);
            }
        }
        public string content1;
        public string content2;
        public static List<Point> ListPosNode = new List<Point>();
        //Thêm vào Toolbox
        static Dictionary<string, List<Node>> map;
        public static Dictionary<string, List<Node>> Map
        {
            get
            {
                if (map == null)
                {
                    map = new Dictionary<string, List<Node>>();
                    map.Add("IN", new List<Node>());
                    map.Add("MN", new List<Node>());
                    map.Add("AE", new List<Node>());
                }
                return map;
            }
        }
        public static Node CreateNode(string name)
        {
            var node = (Node)Activator.CreateInstance(Type.GetType("simulation02." + name + "Node"));
            var lst = Map[name];
            node.Index = lst.Count;
            lst.Add(node);
            node.content1 = name;
            return node;
        }
        public static Node deleteNode(string name)
        {
            var node = (Node)Activator.CreateInstance(Type.GetType("simulation02." + name + "Node"));
            var lst = Map[name];
            node.Index = lst.Count;
            lst.Remove(node);
            return node;
        }

        public String Node_Port;
        public String Node_Id;
        public String Node_Name;
        public String Node_Ip;
        public int Node_Range;
        public void MoveTo(Point pt)
        {
            Left = pt.X - (Width >> 1);
            Top = pt.Y - (Height >> 1);
        }
        bool capture;

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (mevent.Clicks >= 2)
            {
                InfoNode infoNode = InfoNode.GetInstance();
                infoNode.SetData(this);
                infoNode.ShowDialog();
                infoNode.SetAgainData(this);
                Simulation.writeToItemSettingFile(this);
                infoNode.i = 0;
            }
            if (mevent.Button == MouseButtons.Right)
            {
                delete del = new delete();
                del.ShowDialog();
            }
            capture = true;
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if (index >= 0 && capture)
            {
                Left += mevent.X;
                Top += mevent.Y;
            }
            capture = false;
        }
        public Point Center
        {
            get
            {
                return new Point(Left + Width / 2, Top + Height / 2);
            }
        }
        public bool InRange(Node node)
        {
            var o1 = Center;
            var o2 = node.Center;
            var x = o1.X - o2.X;
            var y = o1.Y - o2.Y;
            Range = Node_Range;
            return x * x + y * y <= Range * Range;
        }
        public bool InDistance(Node node)
        {
            var o1 = Center;
            var o2 = node.Center;
            var x = o1.X - o2.X;
            var y = o1.Y - o2.Y;
            Range = Node_Range;
            return x * x + y * y <= Range * Range/4;
        }
        public static void Tranversal(Action<Node> callback)
        {
            foreach (var p in Map)
            {
                foreach (var node in p.Value)
                {
                    callback.Invoke(node);
                }
            }
        }
        public List<Node> GetNodeInRange()
        {
            var lst = new List<Node>();
            Tranversal((node) =>
            {
                if (node != this && InRange(node))
                    lst.Add(node);
            });
            return lst;
        }
        public static Node lst_IN;
    }
    class INNode : Node
    {
        public INNode()
        {
            Height = 18;
            Width = 18;
            BackColor = Color.YellowGreen;
            ForeColor = Color.White;
        }
    }
    class AENode : Node
    {
        public AENode()
        {
            BackColor = Color.Blue;
        }
    }
    class MNNode : Node
    {
        public MNNode()
        {
            BackColor = Color.Red;
            ForeColor = Color.White;
        }
    }
}
