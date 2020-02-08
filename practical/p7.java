import java.awt.*;
import java.sql.*;
import javax.swing.*;
import java.awt.event.*;
class test extends JFrame implements ActionListener
{
JButton bi,bu,bd,bdis;
JLabel la,ln,lb,lp,ladd,display;
JTextField ta,tn,tb,tp;
JTextArea address;
Connection conn;
Statement st;
PreparedStatement pst;
ResultSet rs;
test()
{
setLayout(new FlowLayout());
bi=new JButton("INSERT");
bu=new JButton("UPDATE");
bd=new JButton("DELETE");
bdis=new JButton("DISPLAY");
la=new JLabel("Enter Your Account No:");
ln=new JLabel("Enter Your Name:");
lb=new JLabel("Enter Balance:");
lp=new JLabel("Enter Your Phone No:");
display=new JLabel("Label");
ladd=new JLabel("Enter Your Address:");
ta=new JTextField(10);
tn=new JTextField(10);
tb=new JTextField(10);
tp=new JTextField(10);
address=new JTextArea(4,20);
add(la);
add(ta);
add(ln);
add(tn);
add(lb);
add(tb);
add(lp);
add(tp);
add(ladd);
add(address);
add(bdis);
add(bi);
add(bu);
add(bd);
add(display);
bi.addActionListener(this);
bu.addActionListener(this);
bd.addActionListener(this);
bdis.addActionListener(this);
setSize(300,300);
setVisible(true);
try
{
conn=DriverManager.getConnection("jdbc:mysql://localhost:3306/gec","root","gecpatan");
}
catch(Exception e){System.out.println("NOT CONNECT...TRY AGAIN!!!");}
}
public void actionPerformed(ActionEvent e)
{
if(e.getSource()==bi)
{
String query="INSERT INTO bank(AccountNo,CustomerName,Balance,Phone,Address) VALUES(?,?,?,?,?)";
try
{
pst=conn.prepareStatement(query);
pst.setInt(1,Integer.parseInt(ta.getText()));
pst.setString(2,tn.getText());
pst.setInt(3,Integer.parseInt(tb.getText()));
pst.setString(4,tp.getText());
pst.setString(5,address.getText());
pst.executeUpdate();
display.setText("DATA INSERTED SUCESSFULLY...");
JOptionPane.showMessageDialog(this,"DATA INSERTED SUCESSFULLY...");
}
catch(Exception ae){display.setText(ae.getMessage());}
}
if(e.getSource()==bu)
{
String query="UPDATE bank SET CustomerName=?, Balance=?, Phone=?, Address=? WHERE AccountNo=?";
try
{
pst=conn.prepareStatement(query);
pst.setString(1,tn.getText());
pst.setInt(2,Integer.parseInt(tb.getText()));
pst.setString(3,tp.getText());
pst.setString(4,address.getText());
pst.setInt(5,Integer.parseInt(ta.getText()));
pst.executeUpdate();
JOptionPane.showMessageDialog(this,"DATA UPDATED SUCESSFULLY...");
}
catch(Exception oe){display.setText(oe.getMessage());}
}
if(e.getSource()==bd)
{
try
{
st=conn.createStatement();
st.executeUpdate("delete from bank");
JOptionPane.showMessageDialog(this,"DATA DELETED SUCESSFULLY...");
}
catch(Exception oe){display.setText(oe.getMessage());}
}
if(e.getSource()==bdis)
{
try
{
st=conn.createStatement();
rs=st.executeQuery("select * from bank where balance > 20000");
while(rs.next())
{
JOptionPane.showMessageDialog(this,rs.getInt(1)+"\n"+rs.getString(2)+"\n"+rs.getInt(3)+"\n"+rs.getString(4)+"\n"+rs.getString(5)+"\n");
} 
}
catch(Exception oe){display.setText(oe.getMessage());}
}
}
}
class example
{
public static void main(String args[])
{
test t=new test();
}
}