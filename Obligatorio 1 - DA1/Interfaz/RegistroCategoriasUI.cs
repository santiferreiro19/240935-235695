﻿using Managers;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class RegistroCategoriasUI : UserControl
    {
        private Repositorio Repo;
        private Categoria unaCategoriaLocal;
        public RegistroCategoriasUI(Repositorio unRepositorio)
        {
            Repo = unRepositorio;
            unaCategoriaLocal = new Categoria();
            InitializeComponent();
        }
        private void ActualizarVincularListBox()
        {
            lstPalabrasClave.DataSource = null; //se necesita para actualizar en cada ingreso
            lstPalabrasClave.DataSource = this.unaCategoriaLocal.ListaPalabras;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            ManagerCategoria manager = new ManagerCategoria(this.Repo);
            if (txtPalabraClave.Text != "")
            {
                try
                {
                    PalabraRepetidaEnCategoriaLocal();
                    manager.ValidarPalabraClaveRepetida(txtPalabraClave.Text);
                    manager.ListaPalabrasClaveLLena(this.unaCategoriaLocal);
                    PalabraClave palabraTemporal = new PalabraClave(txtPalabraClave.Text);
                    unaCategoriaLocal.ListaPalabras.Add(palabraTemporal);
                    ActualizarVincularListBox();
                    txtPalabraClave.Text = "";
                }
                catch (ExceptionListaPalabrasClaveLlena lleno)
                {
                    MessageBox.Show("La lista de palabras clave esta llena");
                    txtPalabraClave.Text = "";
                }
                catch (ExceptionPalabraClaveRepetida repetida)
                {
                    MessageBox.Show("La palabra clave esta repetida");
                    txtPalabraClave.Text = "";
                }
            }
            else
            {
                MessageBox.Show("La palabra clave esta vacia");
            }
        }
        private void PalabraRepetidaEnCategoriaLocal()
        {
            PalabraClave palabraTemporal = new PalabraClave(txtPalabraClave.Text);
            foreach (PalabraClave palabraBuscar in this.unaCategoriaLocal.ListaPalabras)
                if (palabraBuscar.Palabra == palabraTemporal.Palabra)
                {
                    throw new ExceptionPalabraClaveRepetida("la palabra clave esta repetida");
                }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ManagerCategoria manager = new ManagerCategoria(this.Repo);
            if (txtNombre.Text != "")
            {
                try
                {
                    this.unaCategoriaLocal.Nombre = txtNombre.Text;
                    manager.ValidacionAgregarCategoria(this.unaCategoriaLocal);
                    this.unaCategoriaLocal = new Categoria();
                    ActualizarVincularListBox();
                    txtNombre.Text = "";
                    txtPalabraClave.Text = "";
                    MessageBox.Show("Categoria Agregada Correctamente!");
                }
                catch (ExceptionNombreCategoria nombre)
                {
                    MessageBox.Show("El largo del nombe es menor a 3 o mayor a 15");
                    txtNombre.Text = "";
                }
                catch (ExceptionNombreCategoriaRepetido nombreRepetido)
                {
                    MessageBox.Show("El Nombre de la categoria esta repetido"); ;
                    txtNombre.Text = "";
                }
            }

        }

        private void panelAgregar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RegistroCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                using (ContextoFinanzas db = new ContextoFinanzas())
                {
                    db.Database.Connection.Open();
                    db.Database.Connection.Close();

                }
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                this.Enabled = false;
                MessageBox.Show("Error: La base de datos no se encuentra disponible");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                this.Enabled = false;
                MessageBox.Show("Error: La base de datos no se encuentra disponible");
            }

        }
    }
}
