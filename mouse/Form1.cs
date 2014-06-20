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
        const int TEXI_MAX = 2001;

        Label[] chrs = new Label[TEXI_MAX];
        int[] iVX = new int[TEXI_MAX];
        int[] iVY = new int[TEXI_MAX];

        int iVelX = rand.Next(15);
        int iVelY = rand.Next(15);

        int chrnum;
        int time;

       

        private static Random rand = new Random();

        //�R���X�g���X�^
        //Form1�N���X�����������Ƃ��Ɏ��s
        //���ʂȊ֐�
        public Form1()
        {
            chrnum = TEXI_MAX;

            time = 500;

            InitializeComponent();
            
            //���x���̐���

            for (int i = 0; i < TEXI_MAX; i++)
            {
                chrs[i] = new Label();
                chrs[i].AutoSize = true; //�~�\
                chrs[i].Text = "(�������m)";
                chrs[i].Left = rand.Next(ClientSize.Width);
                chrs[i].Top = rand.Next(ClientSize.Height);
                chrs[i].Font = new Font("HGS�n�p�p�߯�ߑ�",15);
                chrs[i].ForeColor = Color.FromArgb(120,60,120);
                Controls.Add(chrs[i]);//�t�H�[���ɒǉ�

                iVX[i] = rand.Next(-10,10);
                iVY[i] = rand.Next(-10,10);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (chrnum > 0)
            {
                time--;
                label3.Text = "Time:" + time;
            }
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
                    label2.Visible = false;
                }

                //���x���𓮂���
                for (int i = 0; i < TEXI_MAX; i++)
                {
                    //�L�����N�^�[���L����
                    if (chrs[i].Visible == false)
                    {
                        continue;
                    }

                    //���x���̈ړ�
                    chrs[i].Left += iVX[i];
                    chrs[i].Top += iVY[i];
                    //���x���̒��˕Ԃ�
                    if ((chrs[i].Left < 0) || (chrs[i].Left + chrs[i].Width > ClientSize.Width))
                    {
                        chrs[i].Left -= iVX[i];
                        iVX[i] = -iVX[i];
                    }
                    if ((chrs[i].Top < 0) || (chrs[i].Top + chrs[i].Height > ClientSize.Height))
                    {
                        chrs[i].Top -= iVY[i];
                        iVY[i] = -iVY[i];
                    }
                    //�}�E�X�Ƃ̓����蔻��
                    if (    (  cpos.X>= chrs[i].Left)
                     && (cpos.X < chrs[i].Left+chrs[i].Width)
                     && ( cpos.Y >= chrs[i].Top)
                     && (cpos.X < chrs[i].Top + ClientSize.Height))
                    {
                        iVX[i] = 0;
                        iVY[i] = 0;
                        chrs[i].Visible = false;
                        chrnum--;
                        if (chrnum == 0)
                        {
                            MessageBox.Show("�N���A");
                        }
                    }
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
