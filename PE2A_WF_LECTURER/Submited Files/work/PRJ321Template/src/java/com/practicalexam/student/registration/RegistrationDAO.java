/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.practicalexam.student.registration;

import com.practicalexam.student.connection.DBUtilities;
import java.io.Serializable;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.naming.NamingException;

/**
 *
 * @author Ly Gia Hoang
 */
public class RegistrationDAO implements Serializable{
     public static boolean checkLogin(String username, String password) 
             throws SQLException, NamingException, ClassNotFoundException{
        boolean check = false;
            // Student Call function
            Connection con = null;
            PreparedStatement stm = null;
            ResultSet rs = null;
            
            try {
                con = DBUtilities.makeConnection();
                if(con != null) {
                    // check = objectDAO.checkLogin(username, password);
                    String sql = "Select doctorId "
                            + "From tbl_Doctor "
                            + "Where doctorId = ? And password = ?";
                    stm = con.prepareStatement(sql);
                    stm.setString(1, username);
                    stm.setString(2, password);
                    
                    rs = stm.executeQuery();
                    if(rs.next()) {
                        return true;
                    }
                }
            }
             finally {
                if(rs != null) {
                    rs.close();
                }
                if(stm != null) {
                    stm.close();
                }
                if(con != null) {
                    con.close();
                }
            }
        
        return check;
    }
     
     public static int searchByLastname(String lastname) {
        int result = -1;
        try {
            // Student call function
            
            // result = objectDAO.searchLastname(lastname).size();
            
            //
        } catch (Exception e) {
        }
        return result;
    }
     
    public static boolean deleteAccount(String username) {
        boolean check = false;
        try {
            // Student call function
            
            // check = objectDAO.deleteAccount(username);
            
            //
        } catch (Exception e) {
        }
        return check;
    }
    
    public static boolean insertAccount(String username, String password, String lastName, Boolean isAdmin) {
        boolean check = false;
        try {
            // Student call function
            
            // ObjectDTO dto = new ObjectDTO(String username, String password, String lastName, Boolean isAdmin);
            // check = objectDAO.insertAccount(dto);
            
            //
        } catch (Exception e) {
        }
        return check;
    }
    
    public static boolean updateAccount(String username, String password, String lastName, Boolean isAdmin) {
        boolean check = false;
        try {
            // Student call function
            
            // ObjectDTO dto = new ObjectDTO(String username, String password, String lastName, Boolean isAdmin);
            // check = objectDAO.updateAccount(dto);
            
            //
        } catch (Exception e) {
        }
        return check;
    }
}
