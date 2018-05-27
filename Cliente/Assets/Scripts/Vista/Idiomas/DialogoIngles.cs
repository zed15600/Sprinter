public class DialogoIngles :  IDialogo {

    private string[] lineasDeDialogo;

    public string[] cargarDialogoImpedimento(string scrumMaster) {
        lineasDeDialogo = new string[] {
                    "Oh no! It seems someone is in trouble! D:",
                    "As a team you must support each other to face the problem together.",

                    scrumMaster + ", as the Scrum Master you should  help the team members with their problems and motivate them!.",
                    ""
                    };
        return lineasDeDialogo;
    }

    public string[] cargarDialogoFinSprint(int indice, string scrumMaster) {
        switch (indice) {
            case 11:
                lineasDeDialogo = new string[] {
                    "The Sprint is over and I have showed the developed functionality to the client.",
                    "Here is the feedback.",
                    ""
                    };
                return lineasDeDialogo;
            //Dialogo Final del primer Sprint - Listo
            case 12:
                lineasDeDialogo = new string[] {
                    "Good job in the first Sprint!",
                    "It's up to you now to finish the rest of the stories! I will still support you with priorization and keep you informed about the client's wishes.",
                    "Best of luck! Meow!",
                    ""
                    };
                return lineasDeDialogo;
        }
        return new string[] { "" };
    }

    public string [] cargarDialogosIteracion(int indice, string scrumMaster) {
            switch (indice) {
                //Scrum Planning - Listo
                case 1:
                    lineasDeDialogo = new string[] {
                    "Welcome to the Scrum Team!",
                    "We are going to work as a team to build a project using the agile framework Scrum!",
                    "I'm the product owner and I have gathered the client's wishes.",
                    "We call these the user stories, they have priority and points based in effort and time.",
                    scrumMaster + " will be your Scrum Master and they are gonna help you keep up with Scrum concepts. :D",
                    "You must develop all user stories to finish the project and win!",
                    "Good Luck!\n" +
                    "Meow! (=^･ｪ･^=))ﾉ彡☆ ",
                    ""};
                return lineasDeDialogo;
            //Sprint Planning - Listo
            case 2:
                    lineasDeDialogo = new string[] {
                    "The Sprint Planning's just begun!",
                    "Project in Scrum are developed within cycles (or iterations) of set time",
                    "These iterations are called Sprints.",
                    "At the end of every Sprint we must have a functional product that the client can try! :D",
                    "We must select which stories are going to be developed in the first Sprint.",
                    "As the Product Owner I have priorized them, please choose based on the workload you think you can manage and what would make a good first prototype" +
                    " for the client.",
                    "We must communicate as a team to select these stories! (=^･ω･^=)," +
                    ""};
                return lineasDeDialogo;
            //Sprint Planning advertencia de votación. - Listo
            case 3:
                    lineasDeDialogo = new string[] {
                    "Soon a vote will begin so each of you can express your opinion.",
                    "When you are ready, please vote in your mobile devices!",
                    ""
                    };
                return lineasDeDialogo;
            //Sprint - Listo
            case 4:
                    lineasDeDialogo = new string[] {
                    "The Sprint is here!",
                    "We must complete the stories we selected before we run out of days.",
                    "Let's start picking a user story to work today.",
                    ""
                    };
                return lineasDeDialogo;
            //Reunion Diaria - Listo
            case 5:
                    lineasDeDialogo = new string[] {
                    "In Scrum the team holds a daily meeting to talk about current work and report issues",
                    "This meeting is called the Daily Scrum Meeting! (Pretty original, I must say!)",
                    "Use this time to discuss what is the best way to complete this task as a team!",
                    "We must satisfy all the acceptance criteria to complete the user story.",
                    "After the timer is up, the development will start, use your time wisely!",
                    "Focus on completing the task and working as a team!",
                    "All the best!  (=^ ◡ ^=)",
                    ""
                    };
                return lineasDeDialogo;

            //Minijuego - Listo
            case 6:
                    lineasDeDialogo = new string[] {
                    "The development starts now!.",
                    "The development process in most frameworks is iterative.",
                    "This means, design, development and testing is done based on the focused work.",
                    "Now the focus is the user story.",
                    "The development of the story, will be in these three phases design, development and testing, each phase lasts 2 minutes.",
                    "The objective is to successfully complete all three phases and all the acceptance criteria.",
                    "In the design phase you must briefly design on paper what you need to build.",
                    "In the development phase you must use all the materials you can find to build what's been designed.",
                    "In the testing phase you must check if the built product satisfies all the acceptance criteria, if not you can use the time to complete it.",
                    "In each phase you can press \"Continue\" to proceed to the next phase, you can actually stack the remaining time in the next phase this way!",
                    "To complete a story you only need to satisfy the criteria, but you will get more score if you do it faster!",
                    "Do you best!! :3",
                    ""
                    };
                return lineasDeDialogo;
            //Minijuego terminado - Listo
            case 7:
                    lineasDeDialogo = new string[] {
                    "Time's Up!",
                    scrumMaster + ", please check the completed criteria and mark it.",
                    ""
                    };
                return lineasDeDialogo;
            //Resultados - Listo
            case 8:
                    lineasDeDialogo = new string[] {
                    "Here are the development results!.",
                    "If you completed all the criteria you can proceed with other stories.",
                    "If not you must try again until you complete this one.",
                    "Good Job anyways! :D",
                    ""
                    };
                return lineasDeDialogo;
            //Resultados Boton - Listo
            case 9:
                    lineasDeDialogo = new string[] {
                    "The Sprint will continue until you complete all the work or you run out of days.",
                    "The key is using your time wisely and working as a team! ฅ(＾・ω・＾ฅ)",
                    ""
                    };
                return lineasDeDialogo;
        }
        return new string[] { "" };
    }
}
