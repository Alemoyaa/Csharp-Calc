/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Modelo;

import javax.swing.JOptionPane;

/**
 *
 * @author Matt
 */
public class Modelo {

    public double Suma(double a, double b) {
        return a + b;
    }

    public double Resta(double a, double b) {
        return a - b;
    }

    public int multiplicacion(int a, int b) {
        int c = a * b;
        return c;
    }

    public float divide(float a, float b) {
        float c = 0;
        if (b == 0) {
            
        } else {
            c = a / b;
        }
        return c;
    }

    public double raizCuadrado(double a) {
        double c = Math.sqrt(a);
        return c;
    }
    public double raizN(double a,int b){
        //return Math.pow(Math.E, Math.log(num)/root);
        double c = Math.pow(Math.E,Math.log(a)/b);
        return c;
    }

    public int Cuadrado(int a) {
        int c = a * a;
        return c;
    }

    public int CuadradoN(int a, int b) {
        int c = 1;
        if (b == 0) {
            c = 1;
        } else {
            for (int i = 0; i < b; i++) {
                c *= a;
            }
        }
        return c;
    }
}
