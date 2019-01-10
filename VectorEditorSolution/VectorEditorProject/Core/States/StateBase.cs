using System.Drawing;
using System.Windows.Forms;

namespace VectorEditorProject.Core.States
{
    /// <summary>
    /// Базовое состояние
    /// </summary>
    public abstract class StateBase
    {
        /// <summary>
        /// Рисование
        /// </summary>
        /// <param name="graphics"></param>
        public virtual void Draw(Graphics graphics)
        {
        }

        /// <summary>
        /// Нажание кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void MouseDown(object sender, MouseEventArgs e)
        {
        }

        /// <summary>
        /// Отжатие кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void MouseUp(object sender, MouseEventArgs e)
        {
        }

        /// <summary>
        /// Движение мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void MouseMove(object sender, MouseEventArgs e)
        {
        }

        /// <summary>
        /// Обновление
        /// </summary>
        public virtual void Update()
        {
        }
    }
}
