/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controlador;

import Vista.Window;
import Modelo.Modelo;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

/**
 *
 * @author Matt
 */
public class Controlador implements ActionListener {

    public Window w1;
    public Modelo m1;
    private String panGrande = "";
    private int op;
    private int num1,num2;
    private boolean borrar=false,funciona;
    private double resultado=0;

    public Controlador(Window w1, Modelo m1) {
        this.w1 = w1;
        this.m1 = m1;
        w1.setVisible(true);
        this.iniciar_vista();
    }

    public void iniciar_vista() {
        w1.setLocationRelativeTo(null);
        this.w1.jB0.addActionListener(this);
        this.w1.jB1.addActionListener(this);
        this.w1.jB2.addActionListener(this);
        this.w1.jB3.addActionListener(this);
        this.w1.jB4.addActionListener(this);
        this.w1.jB5.addActionListener(this);
        this.w1.jB6.addActionListener(this);
        this.w1.jB7.addActionListener(this);
        this.w1.jB8.addActionListener(this);
        this.w1.jB9.addActionListener(this);
        this.w1.jBDivision.addActionListener(this);
        this.w1.jBExponente2.addActionListener(this);
        this.w1.jBExponenteN.addActionListener(this);
        this.w1.jBIgual.addActionListener(this);
        this.w1.jBMultiplicacion.addActionListener(this);
        this.w1.jBRaiz2.addActionListener(this);
        this.w1.jBRaizN.addActionListener(this);
        this.w1.jBResta.addActionListener(this);
        this.w1.jBSuma.addActionListener(this);
        this.w1.jBCLR.addActionListener(this);
    }

    public void actionPerformed(ActionEvent e) {
        Object boton = e.getSource(); // guarda el boton pulsado
        if(borrar){ // si el usuario pulso iguals esto es para borrar lo que estaba en pantalla
            mostrarPantalla("");
            resultado = 0;
            borrar=false;
        }
        numero(boton);// muestra el boton pulsado en la pantalla
        if( boton == this.w1.jBDivision){ // los op son para saber que operacion esta haciendo el usuario
            try {
                num1 = Integer.parseInt(panGrande);
            } catch (NumberFormatException f) {
                this.w1.jLPantalla.setText("Error, ingrese un numero");
            }
            op=0;
            panGrande="";
        }else if(boton == this.w1.jBExponente2){
            try {
                num1 = Integer.parseInt(panGrande);
                funciona=true;
            } catch (NumberFormatException f) {
                this.w1.jLPantalla.setText("Error, ingrese un numero");
                funciona=false;
            }
            if(funciona){
                resultado=this.m1.Cuadrado(num1);
                mostrarPantalla("");
                num1 = (int) resultado;
                mostrarPantalla(String.valueOf(resultado));
                panGrande=String.valueOf(num1);
                panGrande="";
            }
        }else if(boton == this.w1.jBExponenteN){
            try {
                num1 = Integer.parseInt(panGrande);
            } catch (NumberFormatException f) {
                this.w1.jLPantalla.setText("Error, ingrese un numero");
            }
            op=1;
            panGrande="";
        }else if(boton == this.w1.jBMultiplicacion){
            try {
                num1 = Integer.parseInt(panGrande);
            } catch (NumberFormatException f) {
                this.w1.jLPantalla.setText("Error, ingrese un numero");
            }
            op=2;
            panGrande="";
        }else if(boton == this.w1.jBRaiz2){
            try {
                num1 = Integer.parseInt(panGrande);
                funciona=true;
            } catch (NumberFormatException f) {
                this.w1.jLPantalla.setText("Error, ingrese un numero");
                funciona=false;
            }
            if(funciona){
                resultado=this.m1.raizCuadrado(num1);
                mostrarPantalla("");
                num1 = (int) resultado;
                mostrarPantalla(String.valueOf(resultado));
                panGrande=String.valueOf(num1);
                panGrande="";
            }
        }else if(boton == this.w1.jBRaizN){
            try {
                num1 = Integer.parseInt(panGrande);
            } catch (NumberFormatException f) {
                this.w1.jLPantalla.setText("Error, ingrese un numero");
            }
            op=3;
            panGrande="";
        }else if(boton == this.w1.jBResta){
            try {
                num1 = Integer.parseInt(panGrande);
            } catch (NumberFormatException f) {
                this.w1.jLPantalla.setText("Error, ingrese un numero");
            }
            op=4;
            panGrande="";
        }else if(boton == this.w1.jBSuma){
            try {
                num1 = Integer.parseInt(panGrande);
            } catch (NumberFormatException f) {
                this.w1.jLPantalla.setText("Error, ingrese un numero");
            }
            op=5;
            panGrande="";
        }else if(boton == this.w1.jBIgual){ // cuando pulsa igual entra en un switch para hacer la operacion que quiere el usuario
            try{
            num2 = Integer.parseInt(panGrande);
            switch(op){
                case 0:
                    if(num2 == 0){
                        mostrarPantalla("Error");
                    }else{
                        resultado=this.m1.divide(num1, num2);
                    }
                    break; 
                case 1:
                    resultado=this.m1.CuadradoN(num1, num2);
                    break;
                case 2:
                    resultado=this.m1.multiplicacion(num1, num2);
                    break;
                case 3:
                    resultado=this.m1.raizN(num1, num2);
                    break;
                case 4:
                    resultado=this.m1.Resta(num1, num2);
                    break;
                case 5:
                    resultado=this.m1.Suma(num1, num2);
                    break;
            }
            mostrarPantalla("");
            mostrarPantalla(String.valueOf(resultado));
            borrar=true;
            }catch(Exception f){
                this.w1.jLPantalla.setText("Error, ingrese un 2do num");
            }
        }
        
    }

    private void numero(Object boton){
        if (boton == this.w1.jB0) {
            mostrarPantalla("0");
        } else if (boton == this.w1.jB1) {
            mostrarPantalla("1");
        } else if (boton == this.w1.jB2) {
            mostrarPantalla("2");
        } else if (boton == this.w1.jB3) {
            mostrarPantalla("3");
        } else if (boton == this.w1.jB4) {
            mostrarPantalla("4");
        } else if (boton == this.w1.jB5) {
            mostrarPantalla("5");
        } else if (boton == this.w1.jB6) {
            mostrarPantalla("6");
        } else if (boton == this.w1.jB7) {
            mostrarPantalla("7");
        } else if (boton == this.w1.jB8) {
            mostrarPantalla("8");
        } else if (boton == this.w1.jB9) {
            mostrarPantalla("9");
        } else if (boton == this.w1.jBCLR) { // borra la pantalla 
            mostrarPantalla("");
        }
    }
    private void mostrarPantalla(String a) {
        if ("".equals(a)) {
            panGrande = "";
        } else {
            panGrande += a;
        }
        this.w1.jLPantalla.setText(panGrande);
    }

}
