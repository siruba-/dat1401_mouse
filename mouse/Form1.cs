using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mouse
{
    public partial class Form1 : Form
    {
        Label[] chrs = new Label[100];
        int[] iVX = new int[100];
        int[] iVY = new int[100];
        
        int iVelX = rand.Next(10);
        int iVelY = rand.Next(10);

        private static Random rand = new Random();

        //�R���X�g���X�^
        //Form1�N���X�����������Ƃ��Ɏ��s
        //���ʂȊ֐�
        public Form1()
        {
            InitializeComponent();
            
            //���x���̐���
            for (int i = 0; i < 100; i++)
            {
                chrs[i] = new Label();
                chrs[i].AutoSize = true; //�~�\
                chrs[i].Text = "(���M���m�m)";
                chrs[i].Left = rand.Next(ClientSize.Width);
                chrs[i].Top = rand.Next(ClientSize.Height);
                Controls.Add(chrs[i]);//�t�H�[���ɒǉ�

                iVX[i] = rand.Next(100);
                iVY[i] = rand.Next(100);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // 2�����N���XPoint�^�̕ϐ�cpos��錾
                Point cpos;

                // cpos�ɁA�}�E�X�̃t�H�[�����W�����o��
                cpos = this.PointToClient(MousePosition);

                // ���x��(�t�H�[��)�Ƀ}�E�X���W��\��
                Text = "" + cpos.X + "," + cpos.Y;

                // �}�E�X���W�Ƀ��x�����������Ă݂悤
                label1.Left = cpos.X;
                label1.Top = cpos.Y;
                int vx = iVelX;
                int vy = iVelY;

                label2.Left +=  vx;
                label2.Top +=   vy;

                //����
                if ((label2.Left < 0) || (label2.Left+label2.Width >  ClientSize.Width))
                {
                   //���E���]
                    label2.Left -= vx;
                    iVelX = -vx;
                }
                if ((label2.Top < 0) || (label2.Top + label2.Height >  ClientSize.Height))
                {
                    //�㉺���]
                    label2.Top -= vy;
                    iVelY = -vy;
                }

                //cpos.x:�}�E�X��X���W
                //cpos.y:�}�E�X��Y���W
                //if((�����P�j�����i�����Q�j�����i�����R�j�����i���傤����S�j
                //������1����S�܂őS�����������Ƃ���if��
                //����1cpos.x��.label2.left�ȏ�
                //�����Qcpos.x��.label2.left+label2.Wideth����
                //�����Rcpos.����.label2.Top�ȏ�
                //�����Scpos.����.label2.Top+label2.Height����
                if(     ( cpos.X >= label2.Left ) 
                    && (cpos.X < label2.Left+label2.Width)
                    && (cpos.Y >= label2.Top  ) 
                    && (cpos.Y < label2.Top+label2.Height))
                {
                    iVelX = 0;
                    iVelY = 0;
                }

            }
            /*
             
             if (label1.Right > ClientSize.Width)
            {
                textBox1.Text = "-10";
                textBox2.Text = "1";
            }
            if (label1.Bottom >ClientSize.Height)
            {
                textBox1.Text = "1";
                textBox2.Text = "-10";
            }*/
            
            catch (Exception )
            {

            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int�^�̔z��ϐ�3���`
            int[] iar = new int[3];
            //[]�̒��ɑd�Y����������邱�Ƃ�
            //�ʂ̏ꏊ�ɃA�N�Z�X�ł���
            iar[0] = 0;
            iar[1] = 1;
            iar[2] = 2;
            MessageBox.Show(iar[0].ToString());
            MessageBox.Show(iar[1].ToString());
            MessageBox.Show(iar[2].ToString());
            int i = 0;
            MessageBox.Show(iar[i].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < 10; i++)
            {
                if (i < 3)
                {
                    continue;
                }
                if (i >= 6)
                {
                    break;
                }
                MessageBox.Show(i.ToString());
                MessageBox.Show("i��" + i);
            }
        }

    }
}
