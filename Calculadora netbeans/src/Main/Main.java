/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Main;

import Controlador.Controlador;
import Modelo.Modelo;
import Vista.Window;

/**
 *
 * @author Matt
 */
public class Main {
    public static void main(String[] args) {
         //nuevas instancias de clase
        Modelo modelo = new Modelo();
        Window window = new Window();
        Controlador controlador = new Controlador( window , modelo );
    }
}
