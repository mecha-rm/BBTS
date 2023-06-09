
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// A panel for the moves.
namespace BBTS
{
    // Info panel for moves.
    public class MoveInfoPanel : MonoBehaviour
    {
        // The id of the move being represented.
        private moveId id;

        // The move that the information came from.
        private Move move;

        // Move Title
        public TMPro.TMP_Text nameText;

        // Move Attributes
        public TMPro.TMP_Text rankText;
        public TMPro.TMP_Text powerText;
        public TMPro.TMP_Text accuracyText;
        public TMPro.TMP_Text energyText;

        // Move Description
        public TMPro.TMP_Text description;

        // Start is called just before any of the Update methods is called the first time.
        private void Start()
        {
            // The SDK has been removed, so the text marking doesn't serve a point anymore.
            // Changes the text colour to show that the language file isn't loaded.
            LanguageManager lm = LanguageManager.Instance;


            // If the text shouldn't be translated.
            if(!lm.TranslateAndLanguageSet())
            {
                // Name
                lm.MarkText(nameText);

                // Rank
                lm.MarkText(rankText);

                // Power
                lm.MarkText(powerText);

                // Accuracy
                lm.MarkText(accuracyText);

                // Energy
                lm.MarkText(energyText);

                // Description
                lm.MarkText(description);
            }

            
        }

        // Gets the move id.
        public moveId Id
        {
            get { return id; }
        }

        // Loads the move into the move info pnael.
        public void LoadMoveInfo(Move move)
        {
            // If the move is null, clear the info.
            if(move == null)
            {
                ClearMoveInfo();
                return;
            }

            // Id
            id = move.Id;

            // Name
            nameText.text = move.Name;

            // Rank
            rankText.text = move.Rank.ToString();

            // Power
            powerText.text = move.GetPowerAsString();

            // Accuracy
            accuracyText.text = move.GetAccuracyAsString();

            // Energy
            energyText.text = move.GetEnergyUsageAsString();

            // Description
            description.text = move.description;

            // Save the move.
            this.move = move;
        }

        // Clears out the move info.
        public void ClearMoveInfo()
        {
            // Id
            id = 0;

            // Name
            nameText.text = "-";

            // Rank
            rankText.text = "-";

            // Power
            powerText.text = "-";

            // Accuracy
            accuracyText.text = "-";

            // Energy
            energyText.text = "-";

            // Description
            description.text = "-";

            // Empty out the object.
            move = null;
        }
    }
}