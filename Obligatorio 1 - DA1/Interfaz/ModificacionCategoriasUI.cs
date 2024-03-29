﻿using Managers;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ModificacionMonedasUI : UserControl
    {
        private Categoria CategoriaSeleccionada;
        private Repositorio Repo;
        public ModificacionMonedasUI(Repositorio UnRepositorio)
        {
            CategoriaSeleccionada = new Categoria();
            Repo = UnRepositorio;
            InitializeComponent();
        }
        private void ActualizarVincularListBox()
        {

            lstCategorias.DataSource = null;
            lstCategorias.DataSource = this.Repo.GetCategorias().GetAll();
        }
        private void ModificacionCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarVincularListBox();
                lstCategorias.SelectedIndex = -1;
                txtNombre.Text = "";
                txtPalabraClave.Text = "";
                lstPalabrasClave.DataSource = null;
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

        private void lstCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoriaSeleccionada = (Categoria)lstCategorias.SelectedItem;
            if (lstCategorias.SelectedIndex != -1)
            {
                txtNombre.Text = CategoriaSeleccionada.Nombre;
                lstPalabrasClave.DataSource = CategoriaSeleccionada.ListaPalabras;
                panel1.Visible = true;
                txtPalabraClave.Text = "";
            }
        }

        private void lstPalabrasClave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPalabrasClave.SelectedIndex != -1)
            {
                txtPalabraClave.Text = (lstPalabrasClave.SelectedItem).ToString();
                lstPalabrasClave.DataSource = CategoriaSeleccionada.ListaPalabras;
            }
        }

        private void btnModificarPalabra_Click(object sender, EventArgs e)
        {
            if (txtPalabraClave.Text != "" && lstPalabrasClave.SelectedIndex != -1)
            {
                ManagerCategoria manager = new ManagerCategoria(Repo);
                if (CategoriaSeleccionada != null)
                {
                    try
                    {
                        String Transformar = lstPalabrasClave.SelectedItem.ToString();
                        PalabraClave palabraAnterior = new PalabraClave(Transformar);
                        manager.ValidacionModificacionDePalabraClave(CategoriaSeleccionada, palabraAnterior.Palabra, txtPalabraClave.Text);
                        CategoriaSeleccionada = Repo.GetCategorias().Get(CategoriaSeleccionada.Id);
                        lstPalabrasClave.DataSource = null;
                        lstPalabrasClave.DataSource = CategoriaSeleccionada.ListaPalabras;
                    }
                    catch (ExceptionPalabraClaveRepetida repetida)
                    {
                        MessageBox.Show("La palabra clave esta repetida");
                    };
                }
                else
                {
                    MessageBox.Show("Seleccione una categoria");
                }
            }
            else
            {
                MessageBox.Show("La palabra clave no puede ser vacia o seleccione una palabra para modificar");
            }
        }

        private void btnModificarNombre_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                ManagerCategoria manager = new ManagerCategoria(Repo);
                if (CategoriaSeleccionada != null)
                {
                    try
                    {
                        manager.ValidacionModificarNombreCategoria(CategoriaSeleccionada, txtNombre.Text);
                        ActualizarVincularListBox();
                    }
                    catch (ExceptionNombreCategoria NoValido)
                    {
                        MessageBox.Show("El largo del nombre debe de ser mayor a 3 y menor que 15");
                    }
                    catch (ExceptionNombreCategoriaRepetido Repetido)
                    {
                        MessageBox.Show("El nombre de la categoria esta repetido");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una categoria");
                }
            }
            else
            {
                MessageBox.Show("El nombre no puede ser vacio");
            }
        }

        private void btnBorrarPalabra_Click(object sender, EventArgs e)
        {
            ManagerCategoria manager = new ManagerCategoria(Repo);
            manager.EliminarPalabraClave(txtPalabraClave.Text);
            lstPalabrasClave.DataSource = null;
            CategoriaSeleccionada = Repo.GetCategorias().Get(CategoriaSeleccionada.Id);
            lstPalabrasClave.DataSource = CategoriaSeleccionada.ListaPalabras;
            txtPalabraClave.Text = "";
        }

        private void btnAgregarPalabra_Click(object sender, EventArgs e)
        {
            ManagerCategoria manager = new ManagerCategoria(Repo);
            if (txtPalabraClave.Text != "")
            {
                try
                {
                    manager.ValidacionAgregarUnaPalabraClave(CategoriaSeleccionada, txtPalabraClave.Text);
                    lstPalabrasClave.DataSource = null;
                    CategoriaSeleccionada = Repo.GetCategorias().Get(CategoriaSeleccionada.Id);
                    lstPalabrasClave.DataSource = CategoriaSeleccionada.ListaPalabras;
                    txtPalabraClave.Text = "";
                }
                catch (ExceptionPalabraClaveRepetida Repetida)
                {
                    MessageBox.Show("La palabra clave esta repetida");
                }
                catch (ExceptionListaPalabrasClaveLlena Llena)
                {
                    MessageBox.Show("La lista de palabras clave esta llena");
                }
            }
            else
            {
                MessageBox.Show("La palabra clave no puede ser Vacia");
            }
        }
    }
}