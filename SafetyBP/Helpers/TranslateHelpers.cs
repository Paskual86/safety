using SafetyBP.Data;
using System.Collections.Generic;

namespace SafetyBP.Helpers
{
    public class TranslateHelpers : ITranslateHelpers
    {
        private Dictionary<ApplicationWordsEnum, string> _spanishWords;
        private Dictionary<ApplicationWordsEnum, string> _englishWords;
        private Dictionary<ApplicationWordsEnum, string> _portuguesWords;

        private Dictionary<LanguagesEnum, string> _languageSpanish;
        private Dictionary<LanguagesEnum, string> _languageEnglish;
        private Dictionary<LanguagesEnum, string> _languagePortugues;

        public TranslateHelpers()
        {
            SetSpanishWords();
            SetEnglishWords();
            SetPortuguesWords();
            SetLanguages();
        }

        public IDictionary<ApplicationWordsEnum, string> GetEnglishWords()
        {
            return _englishWords;
        }

        public IDictionary<ApplicationWordsEnum, string> GetPortuguesWords()
        {
            return _portuguesWords;
        }

        public IDictionary<ApplicationWordsEnum, string> GetSpanishWords()
        {
            return _spanishWords;
        }

        private void SetSpanishWords() 
        {
            _spanishWords = new Dictionary<ApplicationWordsEnum, string>
            {
                { ApplicationWordsEnum.MainMenuCheckList, "CHECK LIST" },
                { ApplicationWordsEnum.MainMenuControlObjects, "CONTROL DE OBJETOS" },
                { ApplicationWordsEnum.MainMenuBoardTasks, "TABLERO DE TAREAS" },
                { ApplicationWordsEnum.MainMenuCorrectiveActions, "ACCIONES CORRECTIVAS" },
                { ApplicationWordsEnum.MainMenuSpontaneousDiversions, "DESVIOS ESPONTANEOS" },
                { ApplicationWordsEnum.MainMenuAddObjects, "ALTA DE OBJETOS" },
                { ApplicationWordsEnum.TitleConfiguration, "CONFIGURACION" },
                { ApplicationWordsEnum.LabelSelectLanguage, "Seleccionar Idioma: " },
                { ApplicationWordsEnum.LabelButtonSave, "Guardar" },
                { ApplicationWordsEnum.LabelButtonBack, "Volver" },
                { ApplicationWordsEnum.LabelButtonNext, "Siguiente" },
                { ApplicationWordsEnum.LabelButtonInactive, "Inactivo" },
                { ApplicationWordsEnum.LabelSynchronizing, "SINCRONIZANDO" },
                { ApplicationWordsEnum.LabelPlaceholderTextComments, "Agregar un comentario..." },
                { ApplicationWordsEnum.LabelDueDate, "Vencimiento" },
                { ApplicationWordsEnum.LabelStartDate, "Inicio" },
                { ApplicationWordsEnum.LabelComments, "Comentarios" },
                { ApplicationWordsEnum.LabelPriorityUnknown, "Deconocida" },
                { ApplicationWordsEnum.LabelPriorityNormal, "Prioridad Normal" },
                { ApplicationWordsEnum.LabelPriorityHigh, "Prioridad Alta" },
                { ApplicationWordsEnum.LabelPriorityCritical, "Prioridad Critica" },
                { ApplicationWordsEnum.DisplayAlertUserSettingTitle, "Información" },
                { ApplicationWordsEnum.DisplayAlertUserSettingMessage, "Idioma actualizado." },
                { ApplicationWordsEnum.DisplayAlertUserSettingButtonOk, "Aceptar" },
                { ApplicationWordsEnum.DisplayAlertUserSettingButtonCancel, "Cancelar" },
                { ApplicationWordsEnum.PageTitleSector, "Sectores" },
                { ApplicationWordsEnum.PageTitleChecklist, "Chequeos" },
                { ApplicationWordsEnum.PageTitleHardware, "Equipos" },
                { ApplicationWordsEnum.PageTitleQuestions, "Preguntas" },
                { ApplicationWordsEnum.PageTitleObjects, "Objetos" },
                { ApplicationWordsEnum.PageTitleTopics, "Temas" },
                { ApplicationWordsEnum.PageTitleTask, "Tareas" },
                { ApplicationWordsEnum.PageTitleTaskDetail, "Tarea" },
                { ApplicationWordsEnum.ToastMessageAppOffline, "Está trabajando sin conexión a internet" },
                { ApplicationWordsEnum.ToastMessageAppOfflineCouldNotLogin, "No hay conexion a internet. No es posible realizar la operacion" },
                { ApplicationWordsEnum.ToastMessageErrorWithCredentialsPleaseLogin, "Ha ocurrido un error con las credenciales, por favor vuelva a iniciar sesión."},
                { ApplicationWordsEnum.ToastMessageThereWasAnErrorTryLater, "Ha ocurrido un error, inténtelo de nuevo más tarde." },
                { ApplicationWordsEnum.ToastMessageTheStatusWasUpdatedSuccessfully, "El estado se modifico correctamente." },
                { ApplicationWordsEnum.ToastMessageThereAreQuestionsWithoutAnswer, "Hay preguntas sin respuesta." },
                { ApplicationWordsEnum.ToastMessageTasksFinishedSuccessfully, "Tareas finalizadas correctamente." },                
                { ApplicationWordsEnum.ToastMessageTaskStatusUpdateSuccessfully, "El estado de la tarea se actualizo correctamente" },
                { ApplicationWordsEnum.ToastMessageTaskStatusUpdateUnsuccessfully, "El estado de la tarea no se pudo actualizar correctamente" },
                { ApplicationWordsEnum.ToastMessageQuestionsUpdateSuccessfully, "Respuestas actualizadas exitosamente." },
                { ApplicationWordsEnum.ToastMessageQuestionChangeStatus, "¿Desea cambiar el estado del relevamiento a inactivo?" },
                { ApplicationWordsEnum.ToastMessageCheckListUpdatedSuccessfully, "Checklist actualizado exitosamente." },
                { ApplicationWordsEnum.ToastMessageOk, "Aceptar" },
                { ApplicationWordsEnum.ToastMessageCancel, "Cancelar" },
                { ApplicationWordsEnum.ToastMessageInformation, "Informacion" },
                { ApplicationWordsEnum.ToastMessageObjectUnfit, "El objeto no está apto para su uso" },
                { ApplicationWordsEnum.ToastMessageIncorrectUserAndPassword, "Usuario o contraseña incorrectos." },
                { ApplicationWordsEnum.LabelButtonYes, "Si" },
                { ApplicationWordsEnum.LabelButtonNo, "No" },
                { ApplicationWordsEnum.LabelButtonComply, "Cumple" },
                { ApplicationWordsEnum.LabelButtonNoComply, "No Cumple" },
                { ApplicationWordsEnum.LabelButtonNoOk, "No ok" },
                { ApplicationWordsEnum.LabelButtonMoreInformation, "Mas informacion" },
                { ApplicationWordsEnum.LabelFile, "Archivo" },
                { ApplicationWordsEnum.CommentIsEmtpy, "No hay comentarios. " },
                { ApplicationWordsEnum.CommentSaveProperly, "El comentario se guardo correctamente." },
                { ApplicationWordsEnum.PhotoSaveProperly, "La foto se guardo correctamente." },
                { ApplicationWordsEnum.LabelButtonFinalize, "Finalizar" },
                { ApplicationWordsEnum.CameraInitialization, "Inicializando camara." },
                { ApplicationWordsEnum.PhotoIsRequired, "La foto es requerida." },
                { ApplicationWordsEnum.LabelButtonOk, "Ok" },
                { ApplicationWordsEnum.PageTitleSpontaneousDiversion, "Desvio" },
                { ApplicationWordsEnum.LabelSectorPicker, "Sectores de planta (seleccionar)"},
                { ApplicationWordsEnum.LabelSector, "Sector" },
                { ApplicationWordsEnum.LabelRisk, "Riesgo" },
                { ApplicationWordsEnum.LabelButtonRiskLow, "Bajo" },
                { ApplicationWordsEnum.LabelButtonRiskMedium, "Medio" },
                { ApplicationWordsEnum.LabelButtonRiskHigh, "Alto" },
                { ApplicationWordsEnum.TextButtonContinueAdding, "Seguir Agregando" },
                { ApplicationWordsEnum.EntryPlaceHolderTextSpontaneousDiversion, "Desvio" },
                { ApplicationWordsEnum.ToastMessageSpontaneousDiversionSaveProperly, "Desvio guardado correctamente." },
                { ApplicationWordsEnum.ToastMessageSpontaneousDiversionThereAreNotItems, "No hay desvios para enviar al server." },
                { ApplicationWordsEnum.PopUpFinalizeSpontaneousDiversionLabel, "Guardando Informacion"},
                { ApplicationWordsEnum.SpeachToTextLabel, "Dictado de comentarios" },
                { ApplicationWordsEnum.UserSettingCloseSessionButton, "Cerrar Sesión" },
                { ApplicationWordsEnum.UserSettingCheckInternetSpeedButton, "Probar conexion a internet" },
                { ApplicationWordsEnum.TitleDisplayLogout, "Cerrar Sesión" },
                { ApplicationWordsEnum.MessageDisplayLogout, "Esta seguro que desea cerrar la sesión?" },
                { ApplicationWordsEnum.ErrorInitializatePageCheckList, "Error inicializando chequeos." },
                { ApplicationWordsEnum.MessageDisplayThereIsNotInternet, "No hay una conexion a internet. No es posible completar la operacion en este momento, por favor intente mas tarde." },
                { ApplicationWordsEnum.TitleDisplaySynchronization, "Sincronizando" },
                { ApplicationWordsEnum.LabelMarkDiversionAsResolve, "MARCAR DESVIO COMO RESUELTO" },
                { ApplicationWordsEnum.PlaceHolderNameOfRound, "Nombre de la ronda" },
                { ApplicationWordsEnum.ToastMessageMissingRoundName, "El nombre de la ronda es requerido"},
                { ApplicationWordsEnum.ToastMessageRoundOpen, "Existe una ronda abierta, ¿Desea continuar agregando desvios?"}

            };
        }

        private void SetEnglishWords()
        {
            _englishWords = new Dictionary<ApplicationWordsEnum, string>
            {
                { ApplicationWordsEnum.MainMenuCheckList, "CHECK LIST" },
                { ApplicationWordsEnum.MainMenuControlObjects, "CONTROL OBJECTS" },
                { ApplicationWordsEnum.MainMenuBoardTasks, "BOARD TASKS" },
                { ApplicationWordsEnum.MainMenuCorrectiveActions, "CORRECTIVE ACTIONS" },
                { ApplicationWordsEnum.MainMenuSpontaneousDiversions, "SPONTANEOUS DIVERSION" },
                { ApplicationWordsEnum.MainMenuAddObjects, "ADD OBJECTS" },
                { ApplicationWordsEnum.TitleConfiguration, "CONFIGURATION" },
                { ApplicationWordsEnum.LabelSelectLanguage, "Select Lenguage: " },
                { ApplicationWordsEnum.LabelButtonSave, "Save" },
                { ApplicationWordsEnum.LabelButtonBack, "Back" },
                { ApplicationWordsEnum.LabelButtonNext, "Next" },
                { ApplicationWordsEnum.LabelButtonInactive, "Inactive" },
                { ApplicationWordsEnum.LabelSynchronizing, "SYNCHRONIZING" },
                { ApplicationWordsEnum.LabelPlaceholderTextComments, "Add comments ..." },
                { ApplicationWordsEnum.LabelDueDate, "Due date" },
                { ApplicationWordsEnum.LabelStartDate, "Start Date" },
                { ApplicationWordsEnum.LabelComments, "Comments" },
                { ApplicationWordsEnum.LabelPriorityUnknown, "Unknown" },
                { ApplicationWordsEnum.LabelPriorityNormal, "Normal priority" },
                { ApplicationWordsEnum.LabelPriorityHigh, "High priority" },
                { ApplicationWordsEnum.LabelPriorityCritical, "Critical priority" },
                { ApplicationWordsEnum.DisplayAlertUserSettingTitle, "Information" },
                { ApplicationWordsEnum.DisplayAlertUserSettingMessage, "Language updated." },
                { ApplicationWordsEnum.DisplayAlertUserSettingButtonOk, "Ok" },
                { ApplicationWordsEnum.DisplayAlertUserSettingButtonCancel, "Cancel" },
                { ApplicationWordsEnum.PageTitleSector, "Areas" },
                { ApplicationWordsEnum.PageTitleChecklist, "Checklists" },
                { ApplicationWordsEnum.PageTitleHardware, "Hardware" },
                { ApplicationWordsEnum.PageTitleObjects, "Objects" },
                { ApplicationWordsEnum.PageTitleTopics, "Topics" },
                { ApplicationWordsEnum.PageTitleQuestions, "Questions" },
                { ApplicationWordsEnum.PageTitleTask, "Tasks" },
                { ApplicationWordsEnum.PageTitleTaskDetail, "Task" },
                { ApplicationWordsEnum.ToastMessageAppOffline, "It is working without internet connection." },
                { ApplicationWordsEnum.ToastMessageAppOfflineCouldNotLogin, "There is not internet connection. It is not possible to complete the operation" },
                { ApplicationWordsEnum.ToastMessageErrorWithCredentialsPleaseLogin, "There was an error with the credentials, please login again."},
                { ApplicationWordsEnum.ToastMessageThereWasAnErrorTryLater, "There was an error, try later on" },
                { ApplicationWordsEnum.ToastMessageTheStatusWasUpdatedSuccessfully, "The status was updated successfully" },
                { ApplicationWordsEnum.ToastMessageThereAreQuestionsWithoutAnswer, "There are questions without answer" },
                { ApplicationWordsEnum.ToastMessageTasksFinishedSuccessfully, "Task finished successfully" },
                { ApplicationWordsEnum.ToastMessageTaskStatusUpdateSuccessfully, "The status of the task was updated successfully" },
                { ApplicationWordsEnum.ToastMessageQuestionsUpdateSuccessfully, "Answers update successfully." },
                { ApplicationWordsEnum.ToastMessageQuestionChangeStatus, "¿Do you want change the status to Inactive?" },
                { ApplicationWordsEnum.ToastMessageCheckListUpdatedSuccessfully, "Checklist updated successfully." },
                { ApplicationWordsEnum.ToastMessageOk, "Ok" },
                { ApplicationWordsEnum.ToastMessageCancel, "Cancel" },
                { ApplicationWordsEnum.ToastMessageInformation, "Information" },
                { ApplicationWordsEnum.ToastMessageObjectUnfit, "The object is not available to be use." },
                { ApplicationWordsEnum.ToastMessageIncorrectUserAndPassword, "Incorrect user and password." },
                { ApplicationWordsEnum.LabelButtonYes, "Yes" },
                { ApplicationWordsEnum.LabelButtonNo, "No" },
                { ApplicationWordsEnum.LabelButtonComply, "Comply" },
                { ApplicationWordsEnum.LabelButtonNoComply, "No comply" },
                { ApplicationWordsEnum.LabelButtonNoOk, "Não ok" },
                { ApplicationWordsEnum.LabelButtonMoreInformation, "More information" },
                { ApplicationWordsEnum.LabelFile, "File" },
                { ApplicationWordsEnum.CommentIsEmtpy, "There isn't comments. " },
                { ApplicationWordsEnum.CommentSaveProperly, "The comment has been saved properly." },
                { ApplicationWordsEnum.PhotoSaveProperly, "The photo has been saved properly." },
                { ApplicationWordsEnum.LabelButtonFinalize, "Finalize" },
                { ApplicationWordsEnum.CameraInitialization, "Camera initialization" },
                { ApplicationWordsEnum.PhotoIsRequired, "The photo is required." },
                { ApplicationWordsEnum.LabelButtonOk, "Ok" },
                { ApplicationWordsEnum.PageTitleSpontaneousDiversion, "Diversion" },
                { ApplicationWordsEnum.LabelSectorPicker, "Areas of planta (select)"},
                { ApplicationWordsEnum.LabelSector, "Area" },
                { ApplicationWordsEnum.LabelRisk, "Risk" },
                { ApplicationWordsEnum.LabelButtonRiskLow, "Low" },
                { ApplicationWordsEnum.LabelButtonRiskMedium, "Medium" },
                { ApplicationWordsEnum.LabelButtonRiskHigh, "High" },
                { ApplicationWordsEnum.TextButtonContinueAdding, "Continue adding" },
                { ApplicationWordsEnum.EntryPlaceHolderTextSpontaneousDiversion, "Diversion" },
                { ApplicationWordsEnum.ToastMessageSpontaneousDiversionSaveProperly, "Diversion save properly." },
                { ApplicationWordsEnum.ToastMessageSpontaneousDiversionThereAreNotItems, "There is not diversions to send to the server." },
                { ApplicationWordsEnum.PopUpFinalizeSpontaneousDiversionLabel, "Saving information"},
                { ApplicationWordsEnum.SpeachToTextLabel, "Spech comments" },
                { ApplicationWordsEnum.UserSettingCloseSessionButton, "Sign Off" },
                { ApplicationWordsEnum.UserSettingCheckInternetSpeedButton, "Test Internet Connection" },
                { ApplicationWordsEnum.TitleDisplayLogout, "Sign Off" },
                { ApplicationWordsEnum.MessageDisplayLogout, "Are you sure to sign off?" },
                { ApplicationWordsEnum.ErrorInitializatePageCheckList, "Error initializating check list." },
                { ApplicationWordsEnum.MessageDisplayThereIsNotInternet, "There is not internet connection. Try later." },
                { ApplicationWordsEnum.TitleDisplaySynchronization, "Synchronization" },
                { ApplicationWordsEnum.LabelMarkDiversionAsResolve, "SET DIVERSION AS RESOLVED" },
                { ApplicationWordsEnum.PlaceHolderNameOfRound, "Round name" },
                { ApplicationWordsEnum.ToastMessageMissingRoundName, "The name of the round is required"},
                { ApplicationWordsEnum.ToastMessageRoundOpen, "There is a round open, ¿Do you want continue adding diversions?"}
            };
        }

        private void SetPortuguesWords()
        {
            _portuguesWords = new Dictionary<ApplicationWordsEnum, string>
            {
                { ApplicationWordsEnum.MainMenuCheckList, "CHECK LIST" },
                { ApplicationWordsEnum.MainMenuControlObjects, "CONTROL DE OBJETOS" },
                { ApplicationWordsEnum.MainMenuBoardTasks, "TABLERO DE TAREAS" },
                { ApplicationWordsEnum.MainMenuCorrectiveActions, "ACCIONES CORRECTIVAS" },
                { ApplicationWordsEnum.MainMenuSpontaneousDiversions, "DESVIOS ESPONTANEOS" },
                { ApplicationWordsEnum.MainMenuAddObjects, "ALTA DE OBJETOS" },
                { ApplicationWordsEnum.TitleConfiguration, "CONFIGURACION" },
                { ApplicationWordsEnum.LabelSelectLanguage, "Seleccionar Lenguage: " },
                { ApplicationWordsEnum.LabelButtonSave, "Guardar" },
                { ApplicationWordsEnum.LabelButtonBack, "Volver" },
                { ApplicationWordsEnum.LabelButtonNext, "Segue" },
                { ApplicationWordsEnum.LabelButtonInactive, "Inativo" },
                { ApplicationWordsEnum.LabelSynchronizing, "SINCRONIZANDO" },
                { ApplicationWordsEnum.LabelPlaceholderTextComments, "Coloca un comentario ..." },
                { ApplicationWordsEnum.LabelDueDate, "Expiração" },
                { ApplicationWordsEnum.LabelStartDate, "Começar" },
                { ApplicationWordsEnum.LabelComments, "Comentários" },
                { ApplicationWordsEnum.LabelPriorityUnknown, "Desconhecido" },
                { ApplicationWordsEnum.LabelPriorityNormal, "Prioridade Normal" },
                { ApplicationWordsEnum.LabelPriorityHigh, "Prioridade máxima" },
                { ApplicationWordsEnum.LabelPriorityCritical, "Prioridade Crítica" },
                { ApplicationWordsEnum.DisplayAlertUserSettingTitle, "Em formação" },
                { ApplicationWordsEnum.DisplayAlertUserSettingMessage, "Linguagem atualizada." },
                { ApplicationWordsEnum.DisplayAlertUserSettingButtonOk, "Aceitar" },
                { ApplicationWordsEnum.DisplayAlertUserSettingButtonCancel, "Cancelar" },
                { ApplicationWordsEnum.PageTitleSector, "Setores" },
                { ApplicationWordsEnum.PageTitleChecklist, "Chequeos" },
                { ApplicationWordsEnum.PageTitleHardware, "Equipos" },
                { ApplicationWordsEnum.PageTitleObjects, "Objetos" },
                { ApplicationWordsEnum.PageTitleQuestions, "Questões" },
                { ApplicationWordsEnum.PageTitleTopics, "Topicos" },
                { ApplicationWordsEnum.PageTitleTask, "Tarefas" },
                { ApplicationWordsEnum.PageTitleTaskDetail, "Tarefa" },
                { ApplicationWordsEnum.ToastMessageAppOffline, "Está trabajando sin conexión a internet" },
                { ApplicationWordsEnum.ToastMessageAppOfflineCouldNotLogin, "No hay conexion a internet. No es posible realizar la operacion" },
                { ApplicationWordsEnum.ToastMessageErrorWithCredentialsPleaseLogin, "Ha ocurrido un error con las credenciales, por favor vuelva a iniciar sesión."},
                { ApplicationWordsEnum.ToastMessageThereWasAnErrorTryLater, "Ha ocurrido un error, inténtelo de nuevo más tarde." },
                { ApplicationWordsEnum.ToastMessageTheStatusWasUpdatedSuccessfully, "El estado se modifico correctamente." },
                { ApplicationWordsEnum.ToastMessageThereAreQuestionsWithoutAnswer, "Hay preguntas sin respuesta." },
                { ApplicationWordsEnum.ToastMessageTasksFinishedSuccessfully, "Tareas finalizadas correctamente." },
                { ApplicationWordsEnum.ToastMessageTaskStatusUpdateSuccessfully, "El estado de la tarea se actualizo correctamente" },
                { ApplicationWordsEnum.ToastMessageQuestionsUpdateSuccessfully, "Respuestas actualizadas exitosamente." },
                { ApplicationWordsEnum.ToastMessageQuestionChangeStatus, "¿Desea cambiar el estado del relevamiento a inactivo?" },
                { ApplicationWordsEnum.ToastMessageCheckListUpdatedSuccessfully, "Checklist actualizado exitosamente." },
                { ApplicationWordsEnum.ToastMessageOk, "Aceptar" },
                { ApplicationWordsEnum.ToastMessageCancel, "Cancelar" },
                { ApplicationWordsEnum.ToastMessageInformation, "Informacion" },
                { ApplicationWordsEnum.ToastMessageObjectUnfit, "El objeto no está apto para su uso" },
                { ApplicationWordsEnum.ToastMessageIncorrectUserAndPassword, "Usuario o contraseña incorrectos." },
                { ApplicationWordsEnum.LabelButtonYes, "Sim" },
                { ApplicationWordsEnum.LabelButtonNo, "Não" },
                { ApplicationWordsEnum.LabelButtonComply, "Cumpre" },
                { ApplicationWordsEnum.LabelButtonNoComply, "Não Cumpre" },
                { ApplicationWordsEnum.LabelButtonOk, "Ok" },
                { ApplicationWordsEnum.LabelButtonNoOk, "Não ok" },
                { ApplicationWordsEnum.LabelButtonMoreInformation, "Mais Informações" },
                { ApplicationWordsEnum.LabelFile, "Archivo" },
                { ApplicationWordsEnum.CommentIsEmtpy, "Não há comentários. " },
                { ApplicationWordsEnum.CommentSaveProperly, "O comentário foi salvo corretamente." },
                { ApplicationWordsEnum.PhotoSaveProperly, "A foto foi salva corretamente." },
                { ApplicationWordsEnum.LabelButtonFinalize, "Finalizar" },
                { ApplicationWordsEnum.CameraInitialization, "Inicializando camara" },
                { ApplicationWordsEnum.PhotoIsRequired, "La foto es requerida." },
                { ApplicationWordsEnum.PageTitleSpontaneousDiversion, "Desvio" },
                { ApplicationWordsEnum.LabelSectorPicker, "Sectores de planta (select)"},
                { ApplicationWordsEnum.LabelSector, "Sector" },
                { ApplicationWordsEnum.LabelRisk, "Riesgo" },
                { ApplicationWordsEnum.LabelButtonRiskLow, "Bajo" },
                { ApplicationWordsEnum.LabelButtonRiskMedium, "Medio" },
                { ApplicationWordsEnum.LabelButtonRiskHigh, "Alto" },
                { ApplicationWordsEnum.TextButtonContinueAdding, "Seguir Agregando" },
                { ApplicationWordsEnum.EntryPlaceHolderTextSpontaneousDiversion, "Desvio" },
                { ApplicationWordsEnum.ToastMessageSpontaneousDiversionSaveProperly, "Diversion save properly." },
                { ApplicationWordsEnum.ToastMessageSpontaneousDiversionThereAreNotItems, "There is not diversions to send to the server." },
                { ApplicationWordsEnum.PopUpFinalizeSpontaneousDiversionLabel, "Saving information"},
                { ApplicationWordsEnum.SpeachToTextLabel, "Dictado de comentarios" },
                { ApplicationWordsEnum.UserSettingCloseSessionButton, "Fechar Sessão" },
                { ApplicationWordsEnum.UserSettingCheckInternetSpeedButton, "Teste a conexão com a Internet" },
                { ApplicationWordsEnum.TitleDisplayLogout, "Sign Off" },
                { ApplicationWordsEnum.MessageDisplayLogout, "Are you sure to sign off?" },
                { ApplicationWordsEnum.ErrorInitializatePageCheckList, "Error initializating check list." },
                { ApplicationWordsEnum.MessageDisplayThereIsNotInternet, "No hay una conexion a internet. Intente mas tarde." },
                { ApplicationWordsEnum.TitleDisplaySynchronization, "Sincronizando" },
                { ApplicationWordsEnum.LabelMarkDiversionAsResolve, "MARCAR DESVIO COMO RESOLVIDO" },
                { ApplicationWordsEnum.PlaceHolderNameOfRound, "Nome redondo" },
                { ApplicationWordsEnum.ToastMessageMissingRoundName, "O nome da rodada é obrigatório"},
                { ApplicationWordsEnum.ToastMessageRoundOpen, "Há uma rodada aberta, ¿Quer continuar adicionando diversões?"}

            };
        }

        private void SetLanguages() 
        {

            _languageSpanish = new Dictionary<LanguagesEnum, string>
            {
                { LanguagesEnum.English, "Ingles" },
                { LanguagesEnum.Spanish, "Español" },
                { LanguagesEnum.Portugues, "Portugues" }
            };

            _languageEnglish = new Dictionary<LanguagesEnum, string>
            {
                { LanguagesEnum.English, "English" },
                { LanguagesEnum.Spanish, "Spanish" },
                { LanguagesEnum.Portugues, "Portuguese" }
            };
            _languagePortugues = new Dictionary<LanguagesEnum, string>
            {
                { LanguagesEnum.English, "Inglesa" },
                { LanguagesEnum.Spanish, "Espanhola" },
                { LanguagesEnum.Portugues, "Portugues" }
            };

        }

        public IDictionary<LanguagesEnum, string> GetLanguages(LanguagesEnum language)
        {
            switch (language) {
                case LanguagesEnum.English: return _languageEnglish;
                case LanguagesEnum.Spanish: return _languageSpanish;
                case LanguagesEnum.Portugues: return _languagePortugues;
                default: return new Dictionary<LanguagesEnum, string>();
            }
        }
    }
}
