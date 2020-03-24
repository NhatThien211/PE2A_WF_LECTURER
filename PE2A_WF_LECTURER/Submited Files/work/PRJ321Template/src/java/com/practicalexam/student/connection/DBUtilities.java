/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.practicalexam.student.connection;

import java.io.Serializable;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import javax.naming.NamingException;

/**
 * @author Kieu Trong Khanh
 */
public class DBUtilities implements Serializable {

    public static Connection makeConnection()
            throws ClassNotFoundException, NamingException, SQLException {
        Connection con = null;
        
        // Students add code to make connection here
        Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
        String url ="jdbc:sqlserver://localhost:1433;databaseName=PracticalTest";
        con = DriverManager.getConnection(url, "sa", "123");
        return con;

    }

}
