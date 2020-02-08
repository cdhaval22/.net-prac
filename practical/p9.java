insert_data procedure created in MySQL Workbench 8.0: 
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_data`(e_no INT(200),ename 
VARCHAR(200),desg VARCHAR(200),dept VARCHAR(200),salary INT(200)) 
BEGIN 
INSERT INTO employee VALUES(e_no,ename,desg,dept,salary); 
END 
➢ update_data procedure created in MySQL Workbench 8.0: 
CREATE DEFINER=`root`@`localhost` PROCEDURE `update_data`(e_no 
INT(200),e_name VARCHAR(200)) 
BEGIN UPDATE employee SET name=e_name WHERE empno=e_no; 
END 
➢ select_data procedure created in MySQL Workbench 8.0: 
CREATE DEFINER=`root`@`localhost` PROCEDURE `select_data`() 
BEGIN SELECT * FROM employee; 
END 
➢ delete_data procedure created in MySQL Workbench 8.0: 
CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_data`() 
BEGIN DELETE FROM employee; 
END



----------------------------------------------------------------
import java.sql.*; 
public class example 
{ 
public static void main(String args[]) 
{ 
try 
{ 
Connection conn=DriverManager.getConnection("jdbc:mysql://localhost:3306/gec","root","root"); 
CallableStatement cs=conn.prepareCall("{CALL insert_data(?,?,?,?,?)}"); 
cs.setInt(1,101); 
cs.setString(2,"Akhilesh"); 
cs.setString(3,"Manager"); 
cs.setString(4,"Humen Resource"); 
cs.setInt(5,70000); 
cs.execute(); 
System.out.println("RECORD INSERTED...!!!"); 
CallableStatement csu=conn.prepareCall("{CALL update_data(?,?)}"); 
csu.setInt(1,101); 
csu.setString(2,"JIgnesh"); 
csu.execute(); 
System.out.println("RECORD UPDATED...!!!"); 
CallableStatement css=conn.prepareCall("{CALL select_data()}"); 
css.execute(); 
CallableStatement csd=conn.prepareCall("{CALL delete_data()}"); 
csd.execute(); 
System.out.println("RECORD DELETE...!!!"); 
conn.close(); 
} catch(Exception e){System.out.println(e.getMessage());} 
} 
} 
