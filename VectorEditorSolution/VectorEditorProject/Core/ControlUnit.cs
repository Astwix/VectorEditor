﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorEditorProject.Core.Commands;

namespace VectorEditorProject.Core
{
    public class ControlUnit
    {
        private List<BaseCommand> _commands;
        private int _currentCommand;
        private readonly PictureBox _canvas;

        private Document _currentDocument = new Document("Untitled", Color.White, new Size(500, 500));

        private Dictionary<Type, Control> _viewUpdateDictionary = new Dictionary<Type, Control>();

        /// <summary>
        /// Конструктор класса управляющего control
        /// </summary>
        public ControlUnit(PictureBox canvas)
        {
            _commands = new List<BaseCommand>();
            _currentCommand = 0;
            _canvas = canvas;

            _viewUpdateDictionary.Add(typeof(AddFigureCommand), _canvas);
        }

        /// <summary>
        /// Обновление view по соответствующей команде (команда -> контрол)
        /// Переделать, т.к. надо обновлять не только контролы
        /// </summary>
        /// <param name="command"></param>
        private void UpdateView(BaseCommand command)
        {
            _viewUpdateDictionary[command.GetType()].Invalidate();
        }

        /// <summary>
        /// Добавление команд
        /// </summary>
        /// <param name="command">Команда</param>
        public void StoreCommand(BaseCommand command)
        {
            _commands = _commands.GetRange(0, _currentCommand); // обрезание списка

            _commands.Add(command);
        }

        /// <summary>
        /// Действие
        /// </summary>
        public void Do()
        {
            BaseCommand cmd = null;
            try
            {
                cmd = _commands[_currentCommand];
            }
            catch (Exception e)
            {
                
            }

            if (cmd == null)
            {
                return;
            }

            cmd.Do();
            _currentCommand = _currentCommand + 1;

            UpdateView(cmd);
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public void Undo()
        {
            BaseCommand cmd = null;
            try
            {
                cmd = _commands[_currentCommand - 1];
            }
            catch (Exception e)
            {

            }

            if (cmd == null)
            {
                return;
            }

            cmd.Undo();
            _currentCommand = _currentCommand - 1;

            UpdateView(cmd);
        }

        /// <summary>
        /// Сброс стека
        /// </summary>
        public void Reset()
        {
            _commands = new List<BaseCommand>();
            _currentCommand = 0;
        }

        /// <summary>
        /// Получить документ
        /// </summary>
        /// <returns></returns>
        public Document GetDocument()
        {
            return _currentDocument;
        }
    }
}