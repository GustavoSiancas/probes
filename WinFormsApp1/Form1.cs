namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int inicio=1, final=1, actual=1, distancia=1;
        Graphics lapiz;
        bool table=false;
        bool[,] MAD= new bool[100,100];
        int[,] MDT = new int[100, 100];
        int auxnod1, auxnod2;
        bool on = false;
        int n;
        char init='A';
        List<Nodo> grafo = new List<Nodo>();
        int contador;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Nodos insuficientes");
            }
            else {
                n = Int32.Parse(textBox1.Text);
                
                timer1.Enabled = true;
                /*button1.Visible = false;
                label1.Visible = false;
                textBox1.Visible = false;*/
            }
                
            button1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            Graphics lienzo=Graphics.FromHwndInternal(this.Handle);
            lienzo.DrawRectangle(Pens.Black, 20, 50, 560, 350);
            foreach (Nodo a in grafo)
            {
                lienzo.DrawEllipse(Pens.Red, a.getx(), a.gety(), 20, 20);
                lienzo.DrawString(a.getletter(), new Font("Arial", 10), Brushes.Red, a.getx()+3, a.gety()+3);
            }
            
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (table == false)
            {
                if (n != 0)
                {

                    grafo.Add(new Nodo(e.X, e.Y, init.ToString()));
                    n--;
                    init++;
                }
                else
                {
                    MessageBox.Show("Nodos completos");
                    foreach (Nodo a in grafo) { listBox1.Items.Add(a.getletter()); }
                    table = true;
                }

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Aquamarine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            lapiz = Graphics.FromHwnd(this.Handle);
            for (int i = 0; i < grafo.Count; i++)
            {
                for(int j = 0; j < grafo.Count; j++)
                {
                    if (MAD[i, j] == true)
                    {
                        lapiz.DrawLine(Pens.Blue, grafo[i].getx()+5, grafo[i].gety()+5, grafo[j].getx()+5, grafo[j].gety()+5);
                        Point p3 = new Point((grafo[i].getx() + grafo[j].getx()) / 2+5, (grafo[i].gety() + grafo[j].gety()) / 2+5);
                        lapiz.DrawString(MDT[i,j].ToString(), new Font("Arial", 8), Brushes.Red, p3);
                    }
                }   
            }
        }

        private void nod2_Click(object sender, EventArgs e)
        {

        }

        private void nod1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MAD[auxnod1, auxnod2] = MAD[auxnod2, auxnod1] = true;
            MDT[auxnod1, auxnod2] = MDT[auxnod2, auxnod1] = Int32.Parse(relacion.Text);
            label5.Text = "" + auxnod1 + "," + auxnod2 + "->" + MAD[auxnod1, auxnod2] + " = " + MDT[auxnod1, auxnod2];
            lapiz = Graphics.FromHwnd(this.Handle);
            Point p1 = new Point(grafo[auxnod1].getx() + 5, grafo[auxnod1].gety() + 5);
            Point p2 = new Point(grafo[auxnod2].getx() + 5, grafo[auxnod2].gety() + 5);
            lapiz.DrawLine(Pens.Blue, p1, p2);
            Point p3=new Point((p1.X+p2.X)/2, (p1.Y+p2.Y)/2);
            lapiz.DrawString(MDT[auxnod1, auxnod2].ToString(), new Font("Arial", 8), Brushes.Red, p3);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            label5.Text = "Why u touch me?";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[,] tabla = new int[50, 3];
           
            inicio = Convert.ToInt32(Jkb1.Text);
            final =  Convert.ToInt32(Jksb2.Text); ;
            for(int i = 0; i < n; i++)
            {
                tabla[i, 0] = 0;
                tabla[i, 1] = int.MaxValue;
                tabla[i, 2] = 0;
            }
            tabla[inicio, 1] = 0;

            //Dijkstra
            actual = inicio;
            do
            {
                //Marcar Nodo Visitado
                tabla[actual, 0] = 1;
                for(int i = 0; i < grafo.Count; i++)
                {
                    if (MAD[actual,i]==true)
                    {
                        //Distancia
                        distancia = MDT[actual, i] + tabla[actual, 1];
                        if (distancia < tabla[i, 1])
                        {
                            tabla[i,1] = distancia;
                            tabla[i, 2] = actual;
                        }

                    }
                }
                int indiceMenor = -1;
                int distanciaMenor = int.MaxValue;
                //hallarmenor
                for (int x=0; x < grafo.Count; x++)
                {
                    if ((tabla[x,1]<distanciaMenor) && (tabla[x, 0] == 0))
                    {
                        indiceMenor = x;
                        distanciaMenor = tabla[x, 1];   
                    }
                }
                actual = indiceMenor;
                
            }while(actual !=-1);
            //RUTA
            List<int> ruta = new List<int>();
            int nodo = final;
            while (nodo != inicio)
            {
                ruta.Add(nodo);
                nodo = tabla[nodo,2];
               
            }
            ruta.Add(inicio);
            ruta.Reverse();
            string valor= "La Distancia minima del nodo " + grafo[inicio].getletter()+" hacia el nodo "+grafo[final].getletter()+" es " + tabla[0,1] +" y la ruta es ";
            foreach(int posicion in ruta)
            {
                string aux = "[" + grafo[posicion].getletter() + "]->";
                valor = valor + aux;
            }
            MessageBox.Show(valor);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (listBox1.SelectedIndex != -1)
            {
                if (on == false)
                {
                    auxnod1 = listBox1.SelectedIndex;
                    nod1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
                    on = true;
                }
                else
                {
                    auxnod2 = listBox1.SelectedIndex;
                    nod2.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
                    on = false;
                }
            }
        }
    }
}