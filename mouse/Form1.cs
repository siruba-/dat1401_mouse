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
        int iVelX = 10;
        int iVelY = 10;

        public Form1()
        {
            InitializeComponent();
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
            
            catch (Exception ee)
            {

            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = "-10";
            label2.Text = "0";
        }

    }
}
