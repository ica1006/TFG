using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantaPiloto.Classes
{
    class ExceptionManagement
    {
        /*Excepciones a controlar
         * 
         * 
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            NullReferenceException 

    */
        public void HandleException(Exception ex)
        {
            switch (ex)
            {
                
                default:
                    Console.WriteLine($"{ex.GetType().Name}, {ex.StackTrace}");
                    break;
            }
        }
    }
}
