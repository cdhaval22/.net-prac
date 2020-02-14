using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
  public class Calculator : Form
  {
    private IContainer components = (IContainer) null;
    private Button btnOne;
    private Button btnTwo;
    private Button btnThree;
    private Button btnSix;
    private Button btnFive;
    private Button btnFour;
    private Button btnNine;
    private Button btnEight;
    private Button btnSeven;
    private Button btnPoint;
    private Button btnZero;
    private Button btnEqual;
    private Button btnPlus;
    private Button btnMinus;
    private Button btnDivision;
    private Button btnMultiplication;
    private Button btnClear;
    private TextBox txtInput;
    private Label lblResult;
    private Button btnCloseBracket;
    private Button btnOpenBrack;
    private Button btnBackspace;
    private Button btnClr;

    public Calculator()
    {
      this.InitializeComponent();
    }

    public static int evaluate(string expression)
    {
      char[] charArray = expression.ToCharArray();
      int num1 = 0;
      bool flag = true;
      Stack<int> intStack = new Stack<int>();
      Stack<char> charStack = new Stack<char>();
      for (int index = 0; index < charArray.Length; ++index)
      {
        if (charArray[index] != ' ')
        {
          if (charArray[index] >= '0' && charArray[index] <= '9')
          {
            StringBuilder stringBuilder = new StringBuilder();
            while (index < charArray.Length && charArray[index] >= '0' && charArray[index] <= '9')
              stringBuilder.Append(charArray[index++]);
            --index;
            intStack.Push(int.Parse(stringBuilder.ToString()));
            ++num1;
          }
          else if (charArray[index] == '(')
            charStack.Push(charArray[index]);
          else if (charArray[index] == ')')
          {
            if (charStack.Contains('('))
            {
              while (charStack.Peek() != '(')
              {
                --num1;
                if (num1 >= 1)
                {
                  intStack.Push(Calculator.Calculator.applyOp(charStack.Pop(), intStack.Pop(), intStack.Pop()));
                }
                else
                {
                  flag = false;
                  break;
                }
              }
              int num2 = (int) charStack.Pop();
            }
            else
            {
              flag = false;
              break;
            }
          }
          else if (charArray[index] == '+' || charArray[index] == '-' || charArray[index] == '*' || charArray[index] == '/')
          {
            while (charStack.Count > 0 && Calculator.Calculator.hasPrecedence(charArray[index], charStack.Peek()))
            {
              --num1;
              if (num1 >= 1)
              {
                intStack.Push(Calculator.Calculator.applyOp(charStack.Pop(), intStack.Pop(), intStack.Pop()));
              }
              else
              {
                flag = false;
                break;
              }
            }
            charStack.Push(charArray[index]);
          }
        }
      }
      while (charStack.Count > 0)
      {
        --num1;
        if (num1 >= 1)
        {
          intStack.Push(Calculator.Calculator.applyOp(charStack.Pop(), intStack.Pop(), intStack.Pop()));
        }
        else
        {
          flag = false;
          break;
        }
      }
      if (num1 >= 1 && intStack.Count == 1)
        return intStack.Pop();
      if (!flag)
      {
        int num2 = (int) MessageBox.Show("Invalid Expression", "Cant Calculate");
        return 0;
      }
      int num3 = (int) MessageBox.Show("Operator Missing", "Cant Calculate");
      return 0;
    }

    public static bool hasPrecedence(char op1, char op2)
    {
      return op2 != '(' && op2 != ')' && (op1 != '*' && op1 != '/' || op2 != '+' && op2 != '-');
    }

    public static int applyOp(char op, int b, int a)
    {
      switch (op)
      {
        case '*':
          return a * b;
        case '+':
          return a + b;
        case '-':
          return a - b;
        case '/':
          if (b == 0)
            throw new NotSupportedException("Cannot divide by zero");
          return a / b;
        default:
          return 0;
      }
    }

    private void btnOne_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += "1";
    }

    private void btnTwo_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += "2";
    }

    private void btnThree_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += "3";
    }

    private void btnFive_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += "5";
    }

    private void btnFour_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += "4";
    }

    private void btnSix_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += "6";
    }

    private void btnSeven_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += "7";
    }

    private void btnEight_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += "8";
    }

    private void btnNine_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += "9";
    }

    private void btnZero_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += "0";
    }

    private void btnPoint_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += ".";
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      this.txtInput.Text = "";
    }

    private void btnOpenBrack_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += " ( ";
    }

    private void btnCloseBracket_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += " ) ";
    }

    private void btnMultiplication_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += " * ";
    }

    private void btnDivision_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += " / ";
    }

    private void btnPlus_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += " + ";
    }

    private void btnMinus_Click(object sender, EventArgs e)
    {
      this.txtInput.Text += " - ";
    }

    private void btnEqual_Click(object sender, EventArgs e)
    {
      this.lblResult.Text = Calculator.Calculator.evaluate(this.txtInput.Text).ToString();
    }

    private void btnBackspace_Click(object sender, EventArgs e)
    {
      int length = this.txtInput.Text.Length;
      if (length > 0 && this.txtInput.Text.EndsWith(" "))
      {
        this.txtInput.Text = this.txtInput.Text.Substring(0, length - 2);
      }
      else
      {
        if (length <= 0)
          return;
        this.txtInput.Text = this.txtInput.Text.Substring(0, length - 1);
      }
    }

    private void btnClr_Click(object sender, EventArgs e)
    {
      this.txtInput.Text = "";
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    public void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Calculator.Calculator));
      this.btnOne = new Button();
      this.btnTwo = new Button();
      this.btnThree = new Button();
      this.btnSix = new Button();
      this.btnFive = new Button();
      this.btnFour = new Button();
      this.btnNine = new Button();
      this.btnEight = new Button();
      this.btnSeven = new Button();
      this.btnPoint = new Button();
      this.btnZero = new Button();
      this.btnEqual = new Button();
      this.btnPlus = new Button();
      this.btnMinus = new Button();
      this.btnDivision = new Button();
      this.btnMultiplication = new Button();
      this.btnClear = new Button();
      this.txtInput = new TextBox();
      this.lblResult = new Label();
      this.btnCloseBracket = new Button();
      this.btnOpenBrack = new Button();
      this.btnBackspace = new Button();
      this.btnClr = new Button();
      this.SuspendLayout();
      this.btnOne.BackColor = Color.Chocolate;
      this.btnOne.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnOne.ForeColor = Color.LightSeaGreen;
      this.btnOne.Location = new Point(24, 241);
      this.btnOne.Name = "btnOne";
      this.btnOne.Size = new Size(112, 68);
      this.btnOne.TabIndex = 19;
      this.btnOne.Text = "1";
      this.btnOne.UseVisualStyleBackColor = false;
      this.btnOne.Click += new EventHandler(this.btnOne_Click);
      this.btnTwo.BackColor = Color.Chocolate;
      this.btnTwo.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnTwo.ForeColor = Color.LightSeaGreen;
      this.btnTwo.Location = new Point(196, 241);
      this.btnTwo.Name = "btnTwo";
      this.btnTwo.Size = new Size(109, 68);
      this.btnTwo.TabIndex = 1;
      this.btnTwo.Text = "2";
      this.btnTwo.UseVisualStyleBackColor = false;
      this.btnTwo.Click += new EventHandler(this.btnTwo_Click);
      this.btnThree.BackColor = Color.Chocolate;
      this.btnThree.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnThree.ForeColor = Color.LightSeaGreen;
      this.btnThree.Location = new Point(358, 241);
      this.btnThree.Name = "btnThree";
      this.btnThree.Size = new Size(112, 68);
      this.btnThree.TabIndex = 2;
      this.btnThree.Text = "3";
      this.btnThree.UseVisualStyleBackColor = false;
      this.btnThree.Click += new EventHandler(this.btnThree_Click);
      this.btnSix.BackColor = Color.Chocolate;
      this.btnSix.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSix.ForeColor = Color.LightSeaGreen;
      this.btnSix.Location = new Point(358, 336);
      this.btnSix.Name = "btnSix";
      this.btnSix.Size = new Size(113, 65);
      this.btnSix.TabIndex = 5;
      this.btnSix.Text = "6";
      this.btnSix.UseVisualStyleBackColor = false;
      this.btnSix.Click += new EventHandler(this.btnSix_Click);
      this.btnFive.BackColor = Color.Chocolate;
      this.btnFive.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnFive.ForeColor = Color.LightSeaGreen;
      this.btnFive.Location = new Point(197, 336);
      this.btnFive.Name = "btnFive";
      this.btnFive.Size = new Size(108, 65);
      this.btnFive.TabIndex = 4;
      this.btnFive.Text = "5";
      this.btnFive.UseVisualStyleBackColor = false;
      this.btnFive.Click += new EventHandler(this.btnFive_Click);
      this.btnFour.BackColor = Color.Chocolate;
      this.btnFour.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnFour.ForeColor = Color.LightSeaGreen;
      this.btnFour.Location = new Point(25, 336);
      this.btnFour.Name = "btnFour";
      this.btnFour.Size = new Size(111, 65);
      this.btnFour.TabIndex = 3;
      this.btnFour.Text = "4";
      this.btnFour.UseVisualStyleBackColor = false;
      this.btnFour.Click += new EventHandler(this.btnFour_Click);
      this.btnNine.BackColor = Color.Chocolate;
      this.btnNine.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnNine.ForeColor = Color.LightSeaGreen;
      this.btnNine.Location = new Point(358, 434);
      this.btnNine.Name = "btnNine";
      this.btnNine.Size = new Size(113, 68);
      this.btnNine.TabIndex = 8;
      this.btnNine.Text = "9";
      this.btnNine.UseVisualStyleBackColor = false;
      this.btnNine.Click += new EventHandler(this.btnNine_Click);
      this.btnEight.BackColor = Color.Chocolate;
      this.btnEight.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnEight.ForeColor = Color.LightSeaGreen;
      this.btnEight.Location = new Point(197, 434);
      this.btnEight.Name = "btnEight";
      this.btnEight.Size = new Size(108, 68);
      this.btnEight.TabIndex = 7;
      this.btnEight.Text = "8";
      this.btnEight.UseVisualStyleBackColor = false;
      this.btnEight.Click += new EventHandler(this.btnEight_Click);
      this.btnSeven.BackColor = Color.Chocolate;
      this.btnSeven.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnSeven.ForeColor = Color.LightSeaGreen;
      this.btnSeven.Location = new Point(25, 434);
      this.btnSeven.Name = "btnSeven";
      this.btnSeven.Size = new Size(111, 68);
      this.btnSeven.TabIndex = 6;
      this.btnSeven.Text = "7";
      this.btnSeven.UseVisualStyleBackColor = false;
      this.btnSeven.Click += new EventHandler(this.btnSeven_Click);
      this.btnPoint.BackColor = Color.Chocolate;
      this.btnPoint.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnPoint.ForeColor = Color.LightSeaGreen;
      this.btnPoint.Location = new Point(196, 521);
      this.btnPoint.Name = "btnPoint";
      this.btnPoint.Size = new Size(109, 68);
      this.btnPoint.TabIndex = 10;
      this.btnPoint.Text = ".";
      this.btnPoint.UseVisualStyleBackColor = false;
      this.btnPoint.Click += new EventHandler(this.btnPoint_Click);
      this.btnZero.BackColor = Color.Chocolate;
      this.btnZero.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnZero.ForeColor = Color.LightSeaGreen;
      this.btnZero.Location = new Point(25, 521);
      this.btnZero.Name = "btnZero";
      this.btnZero.Size = new Size(111, 68);
      this.btnZero.TabIndex = 9;
      this.btnZero.Text = "0";
      this.btnZero.UseVisualStyleBackColor = false;
      this.btnZero.Click += new EventHandler(this.btnZero_Click);
      this.btnEqual.BackColor = Color.Chocolate;
      this.btnEqual.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnEqual.ForeColor = Color.LightSeaGreen;
      this.btnEqual.Location = new Point(526, 521);
      this.btnEqual.Name = "btnEqual";
      this.btnEqual.Size = new Size(201, 68);
      this.btnEqual.TabIndex = 12;
      this.btnEqual.Text = "=";
      this.btnEqual.UseVisualStyleBackColor = false;
      this.btnEqual.Click += new EventHandler(this.btnEqual_Click);
      this.btnPlus.BackColor = Color.Chocolate;
      this.btnPlus.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnPlus.ForeColor = Color.LightSeaGreen;
      this.btnPlus.Location = new Point(526, 429);
      this.btnPlus.Name = "btnPlus";
      this.btnPlus.Size = new Size(90, 68);
      this.btnPlus.TabIndex = 14;
      this.btnPlus.Text = "+";
      this.btnPlus.UseVisualStyleBackColor = false;
      this.btnPlus.Click += new EventHandler(this.btnPlus_Click);
      this.btnMinus.BackColor = Color.Chocolate;
      this.btnMinus.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnMinus.ForeColor = Color.LightSeaGreen;
      this.btnMinus.Location = new Point(637, 429);
      this.btnMinus.Name = "btnMinus";
      this.btnMinus.Size = new Size(90, 68);
      this.btnMinus.TabIndex = 15;
      this.btnMinus.Text = "-";
      this.btnMinus.UseVisualStyleBackColor = false;
      this.btnMinus.Click += new EventHandler(this.btnMinus_Click);
      this.btnDivision.BackColor = Color.Chocolate;
      this.btnDivision.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnDivision.ForeColor = Color.LightSeaGreen;
      this.btnDivision.Location = new Point(637, 333);
      this.btnDivision.Name = "btnDivision";
      this.btnDivision.Size = new Size(90, 68);
      this.btnDivision.TabIndex = 17;
      this.btnDivision.Text = "/";
      this.btnDivision.UseVisualStyleBackColor = false;
      this.btnDivision.Click += new EventHandler(this.btnDivision_Click);
      this.btnMultiplication.BackColor = Color.Chocolate;
      this.btnMultiplication.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnMultiplication.ForeColor = Color.LightSeaGreen;
      this.btnMultiplication.Location = new Point(526, 333);
      this.btnMultiplication.Name = "btnMultiplication";
      this.btnMultiplication.Size = new Size(90, 68);
      this.btnMultiplication.TabIndex = 16;
      this.btnMultiplication.Text = "*";
      this.btnMultiplication.UseVisualStyleBackColor = false;
      this.btnMultiplication.Click += new EventHandler(this.btnMultiplication_Click);
      this.btnClear.BackColor = Color.Chocolate;
      this.btnClear.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnClear.ForeColor = Color.LightSeaGreen;
      this.btnClear.Location = new Point(358, 521);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new Size(113, 68);
      this.btnClear.TabIndex = 18;
      this.btnClear.Text = "CE";
      this.btnClear.UseVisualStyleBackColor = false;
      this.btnClear.Click += new EventHandler(this.btnClear_Click);
      this.txtInput.Font = new Font("Microsoft Sans Serif", 20f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInput.Location = new Point(90, 66);
      this.txtInput.Multiline = true;
      this.txtInput.Name = "txtInput";
      this.txtInput.Size = new Size(637, 76);
      this.txtInput.TabIndex = 0;
      this.lblResult.AutoSize = true;
      this.lblResult.Font = new Font("Microsoft Sans Serif", 20f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblResult.Location = new Point(648, 9);
      this.lblResult.Name = "lblResult";
      this.lblResult.Size = new Size(79, 39);
      this.lblResult.TabIndex = 20;
      this.lblResult.Text = "Ans";
      this.btnCloseBracket.BackColor = Color.Chocolate;
      this.btnCloseBracket.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnCloseBracket.ForeColor = Color.LightSeaGreen;
      this.btnCloseBracket.Location = new Point(637, 241);
      this.btnCloseBracket.Name = "btnCloseBracket";
      this.btnCloseBracket.Size = new Size(90, 68);
      this.btnCloseBracket.TabIndex = 22;
      this.btnCloseBracket.Text = ")";
      this.btnCloseBracket.UseVisualStyleBackColor = false;
      this.btnCloseBracket.Click += new EventHandler(this.btnCloseBracket_Click);
      this.btnOpenBrack.BackColor = Color.Chocolate;
      this.btnOpenBrack.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnOpenBrack.ForeColor = Color.LightSeaGreen;
      this.btnOpenBrack.Location = new Point(526, 241);
      this.btnOpenBrack.Name = "btnOpenBrack";
      this.btnOpenBrack.Size = new Size(90, 68);
      this.btnOpenBrack.TabIndex = 21;
      this.btnOpenBrack.Text = "(";
      this.btnOpenBrack.UseVisualStyleBackColor = false;
      this.btnOpenBrack.Click += new EventHandler(this.btnOpenBrack_Click);
      this.btnBackspace.BackColor = Color.Chocolate;
      this.btnBackspace.BackgroundImage = (Image) componentResourceManager.GetObject("btnBackspace.BackgroundImage");
      this.btnBackspace.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnBackspace.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnBackspace.ForeColor = Color.LightSeaGreen;
      this.btnBackspace.Location = new Point(526, 155);
      this.btnBackspace.Name = "btnBackspace";
      this.btnBackspace.Size = new Size(201, 68);
      this.btnBackspace.TabIndex = 23;
      this.btnBackspace.UseVisualStyleBackColor = false;
      this.btnBackspace.Click += new EventHandler(this.btnBackspace_Click);
      this.btnClr.BackColor = Color.Chocolate;
      this.btnClr.DialogResult = DialogResult.Cancel;
      this.btnClr.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnClr.ForeColor = Color.LightSeaGreen;
      this.btnClr.Location = new Point(25, 155);
      this.btnClr.Name = "btnClr";
      this.btnClr.Size = new Size(280, 68);
      this.btnClr.TabIndex = 24;
      this.btnClr.Text = "Clear";
      this.btnClr.UseVisualStyleBackColor = false;
      this.btnClr.Click += new EventHandler(this.btnClr_Click);
      this.AcceptButton = (IButtonControl) this.btnEqual;
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnClr;
      this.ClientSize = new Size(757, 629);
      this.Controls.Add((Control) this.btnClr);
      this.Controls.Add((Control) this.btnBackspace);
      this.Controls.Add((Control) this.btnCloseBracket);
      this.Controls.Add((Control) this.btnOpenBrack);
      this.Controls.Add((Control) this.lblResult);
      this.Controls.Add((Control) this.txtInput);
      this.Controls.Add((Control) this.btnClear);
      this.Controls.Add((Control) this.btnDivision);
      this.Controls.Add((Control) this.btnMultiplication);
      this.Controls.Add((Control) this.btnMinus);
      this.Controls.Add((Control) this.btnPlus);
      this.Controls.Add((Control) this.btnEqual);
      this.Controls.Add((Control) this.btnPoint);
      this.Controls.Add((Control) this.btnZero);
      this.Controls.Add((Control) this.btnNine);
      this.Controls.Add((Control) this.btnEight);
      this.Controls.Add((Control) this.btnSeven);
      this.Controls.Add((Control) this.btnSix);
      this.Controls.Add((Control) this.btnFive);
      this.Controls.Add((Control) this.btnFour);
      this.Controls.Add((Control) this.btnThree);
      this.Controls.Add((Control) this.btnTwo);
      this.Controls.Add((Control) this.btnOne);
      this.Name = nameof (Calculator);
      this.Text = nameof (Calculator);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
