using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {
                try
                {
                    if ((txtProf.Text == "") || (txtSala.Text == "") ||(txtCurso.Text == "") || (txtData.Text == ""))
                    {
                        MessageBox.Show("Não pode conter campos em branco!");
                    }
                    else
                    {
                        tb.ObjetoSalaAula.Add(new SalaAula { Professor = txtProf.Text, Sala = txtSala.Text, Curso = txtCurso.Text, Data = txtData.Text });
                        tb.SaveChanges();
                        limpacampos();
                        AtualizaGrid();
                        MessageBox.Show("Adicionado com sucesso", "Adicionar");
                    }                   
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        public void limpacampos()
        {
            txtId.Clear();
            txtProf.Clear();
            txtCurso.Clear();
            txtSala.Clear();
            txtData.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {
                try
                {
                    var objeto = tb.ObjetoSalaAula.Find(Convert.ToInt32(txtId.Text));
                    objeto.Professor = txtProf.Text;
                    objeto.Sala = txtSala.Text;
                    objeto.Curso = txtCurso.Text;
                    objeto.Data = txtData.Text;

                    tb.Entry(objeto).State = EntityState.Modified;
                    tb.SaveChanges();
                    MessageBox.Show("Alterado com sucesso", "Alterado");
                    AtualizaGrid();
                    limpacampos();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }


        public void AtualizaGrid()
        {
            using (var tb = new Contexto())
            {
                grid.DataSource = null;
                grid.DataSource = tb.ObjetoSalaAula.ToList();
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtProf.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtSala.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtCurso.Text = grid.CurrentRow.Cells[3].Value.ToString();
            txtData.Text = grid.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {
                try
                {
                    var objeto = tb.ObjetoSalaAula.Find(Convert.ToInt32(txtId.Text));
                    tb.ObjetoSalaAula.Remove(objeto);
                    tb.SaveChanges();
                    MessageBox.Show("Excluido com sucesso", "Excluir");
                    limpacampos();
                    AtualizaGrid();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnLimpa_Click(object sender, EventArgs e)
        {
            limpacampos();
        }
    }
}
