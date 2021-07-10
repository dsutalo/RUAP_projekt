using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace ESRB_category_form
{
    public partial class Form1 : Form
    {
        PredictionModel predictionModel;


        string[,] inputValues;

        public Form1()
        {
            predictionModel = new PredictionModel();
            

            InitializeComponent();
            InitializeComboBoxes();

            button1.Enabled = false;
        }

        private void InitializeComboBoxes()
        {
            var alcoholRef = new List<States>();
            alcoholRef.Add(new States() { ID = "0", State = "false" });
            alcoholRef.Add(new States() { ID = "1", State = "true" });
            cboAlcohol.DataSource = alcoholRef;
            cboAlcohol.DisplayMember = "State";
            cboAlcohol.ValueMember = "ID";

            var animatedBlood = new List<States>();
            animatedBlood.Add(new States() { ID = "0", State = "false" });
            animatedBlood.Add(new States() { ID = "1", State = "true" });
            cboABlood.DataSource = animatedBlood;
            cboABlood.DisplayMember = "State";
            cboABlood.ValueMember = "ID";

            var blood = new List<States>();
            blood.Add(new States() { ID = "0", State = "false" });
            blood.Add(new States() { ID = "1", State = "true" });
            cboBlood.DataSource = blood;
            cboBlood.DisplayMember = "State";
            cboBlood.ValueMember = "ID";

            var bloodNGore = new List<States>();
            bloodNGore.Add(new States() { ID = "0", State = "false" });
            bloodNGore.Add(new States() { ID = "1", State = "true" });
            cboBnG.DataSource = bloodNGore;
            cboBnG.DisplayMember = "State";
            cboBnG.ValueMember = "ID";

            var cartoonViolence = new List<States>();
            cartoonViolence.Add(new States() { ID = "0", State = "false" });
            cartoonViolence.Add(new States() { ID = "1", State = "true" });
            cboCartoon.DataSource = cartoonViolence;
            cboCartoon.DisplayMember = "State";
            cboCartoon.ValueMember = "ID";

            var crudeHumor = new List<States>();
            crudeHumor.Add(new States() { ID = "0", State = "false" });
            crudeHumor.Add(new States() { ID = "1", State = "true" });
            cboCrudeHumor.DataSource = crudeHumor;
            cboCrudeHumor.DisplayMember = "State";
            cboCrudeHumor.ValueMember = "ID";

            var drugReference = new List<States>();
            drugReference.Add(new States() { ID = "0", State = "false" });
            drugReference.Add(new States() { ID = "1", State = "true" });
            cboDrug.DataSource = drugReference;
            cboDrug.DisplayMember = "State";
            cboDrug.ValueMember = "ID";

            var fantasyViolence = new List<States>();
            fantasyViolence.Add(new States() { ID = "0", State = "false" });
            fantasyViolence.Add(new States() { ID = "1", State = "true" });
            cboFantasyViolence.DataSource = fantasyViolence;
            cboFantasyViolence.DisplayMember = "State";
            cboFantasyViolence.ValueMember = "ID";

            var intenseViolence = new List<States>();
            intenseViolence.Add(new States() { ID = "0", State = "false" });
            intenseViolence.Add(new States() { ID = "1", State = "true" });
            cboIntenseViolence.DataSource = intenseViolence;
            cboIntenseViolence.DisplayMember = "State";
            cboIntenseViolence.ValueMember = "ID";

            var language = new List<States>();
            language.Add(new States() { ID = "0", State = "false" });
            language.Add(new States() { ID = "1", State = "true" });
            cboLanguage.DataSource = language;
            cboLanguage.DisplayMember = "State";
            cboLanguage.ValueMember = "ID";

            var lyrics = new List<States>();
            lyrics.Add(new States() { ID = "0", State = "false" });
            lyrics.Add(new States() { ID = "1", State = "true" });
            cboLyrics.DataSource = lyrics;
            cboLyrics.DisplayMember = "State";
            cboLyrics.ValueMember = "ID";

            var matureHumor = new List<States>();
            matureHumor.Add(new States() { ID = "0", State = "false" });
            matureHumor.Add(new States() { ID = "1", State = "true" });
            cboMatureHumor.DataSource = matureHumor;
            cboMatureHumor.DisplayMember = "State";
            cboMatureHumor.ValueMember = "ID";

            var mildBlood = new List<States>();
            mildBlood.Add(new States() { ID = "0", State = "false" });
            mildBlood.Add(new States() { ID = "1", State = "true" });
            cboMildBlood.DataSource = mildBlood;
            cboMildBlood.DisplayMember = "State";
            cboMildBlood.ValueMember = "ID";

            var mildCartoonViolence = new List<States>();
            mildCartoonViolence.Add(new States() { ID = "0", State = "false" });
            mildCartoonViolence.Add(new States() { ID = "1", State = "true" });
            cboMildCV.DataSource = mildCartoonViolence;
            cboMildCV.DisplayMember = "State";
            cboMildCV.ValueMember = "ID";

            var mildFantasyViolence = new List<States>();
            mildFantasyViolence.Add(new States() { ID = "0", State = "false" });
            mildFantasyViolence.Add(new States() { ID = "1", State = "true" });
            cboMildFV.DataSource = mildFantasyViolence;
            cboMildFV.DisplayMember = "State";
            cboMildFV.ValueMember = "ID";

            var mildLanguage = new List<States>();
            mildLanguage.Add(new States() { ID = "0", State = "false" });
            mildLanguage.Add(new States() { ID = "1", State = "true" });
            cboMildLanguage.DataSource = mildLanguage;
            cboMildLanguage.DisplayMember = "State";
            cboMildLanguage.ValueMember = "ID";

            var mildLyrics = new List<States>();
            mildLyrics.Add(new States() { ID = "0", State = "false" });
            mildLyrics.Add(new States() { ID = "1", State = "true" });
            cboMildLyrics.DataSource = mildLyrics;
            cboMildLyrics.DisplayMember = "State";
            cboMildLyrics.ValueMember = "ID";

            var mildSuggestiveThemes = new List<States>();
            mildSuggestiveThemes.Add(new States() { ID = "0", State = "false" });
            mildSuggestiveThemes.Add(new States() { ID = "1", State = "true" });
            cboMildST.DataSource = mildSuggestiveThemes;
            cboMildST.DisplayMember = "State";
            cboMildST.ValueMember = "ID";

            var mildViolence = new List<States>();
            mildViolence.Add(new States() { ID = "0", State = "false" });
            mildViolence.Add(new States() { ID = "1", State = "true" });
            cboMildViolence.DataSource = mildViolence;
            cboMildViolence.DisplayMember = "State";
            cboMildViolence.ValueMember = "ID";

            var noDescriptors = new List<States>();
            noDescriptors.Add(new States() { ID = "0", State = "false" });
            noDescriptors.Add(new States() { ID = "1", State = "true" });
            cboNoDescriptors.DataSource = noDescriptors;
            cboNoDescriptors.DisplayMember = "State";
            cboNoDescriptors.ValueMember = "ID";

            var nudity = new List<States>();
            nudity.Add(new States() { ID = "0", State = "false" });
            nudity.Add(new States() { ID = "1", State = "true" });
            cboNudity.DataSource = nudity;
            cboNudity.DisplayMember = "State";
            cboNudity.ValueMember = "ID";

            var partialNudity = new List<States>();
            partialNudity.Add(new States() { ID = "0", State = "false" });
            partialNudity.Add(new States() { ID = "1", State = "true" });
            cboPartialNudity.DataSource = partialNudity;
            cboPartialNudity.DisplayMember = "State";
            cboPartialNudity.ValueMember = "ID";

            var sexualContent = new List<States>();
            sexualContent.Add(new States() { ID = "0", State = "false" });
            sexualContent.Add(new States() { ID = "1", State = "true" });
            cboSexualContent.DataSource = sexualContent;
            cboSexualContent.DisplayMember = "State";
            cboSexualContent.ValueMember = "ID";


            var sexualThemes = new List<States>();
            sexualThemes.Add(new States() { ID = "0", State = "false" });
            sexualThemes.Add(new States() { ID = "1", State = "true" });
            cboSexualThemes.DataSource = sexualThemes;
            cboSexualThemes.DisplayMember = "State";
            cboSexualThemes.ValueMember = "ID";

            var simulatedGambling = new List<States>();
            simulatedGambling.Add(new States() { ID = "0", State = "false" });
            simulatedGambling.Add(new States() { ID = "1", State = "true" });
            cboSimulatedGambling.DataSource = simulatedGambling;
            cboSimulatedGambling.DisplayMember = "State";
            cboSimulatedGambling.ValueMember = "ID";

            var strongLanguage = new List<States>();
            strongLanguage.Add(new States() { ID = "0", State = "false" });
            strongLanguage.Add(new States() { ID = "1", State = "true" });
            cboStrongLanguage.DataSource = strongLanguage;
            cboStrongLanguage.DisplayMember = "State";
            cboStrongLanguage.ValueMember = "ID";

            var strongSexualContent = new List<States>();
            strongSexualContent.Add(new States() { ID = "0", State = "false" });
            strongSexualContent.Add(new States() { ID = "1", State = "true" });
            cboSSC.DataSource = strongSexualContent;
            cboSSC.DisplayMember = "State";
            cboSSC.ValueMember = "ID";

            var suggestiveThemes = new List<States>();
            suggestiveThemes.Add(new States() { ID = "0", State = "false" });
            suggestiveThemes.Add(new States() { ID = "1", State = "true" });
            cboSuggestiveThemes.DataSource = suggestiveThemes;
            cboSuggestiveThemes.DisplayMember = "State";
            cboSuggestiveThemes.ValueMember = "ID";

            var useOfAlcohol = new List<States>();
            useOfAlcohol.Add(new States() { ID = "0", State = "false" });
            useOfAlcohol.Add(new States() { ID = "1", State = "true" });
            cboUOA.DataSource = useOfAlcohol;
            cboUOA.DisplayMember = "State";
            cboUOA.ValueMember = "ID";

            var useOfDrugsAndAlcohol = new List<States>();
            useOfDrugsAndAlcohol.Add(new States() { ID = "0", State = "false" });
            useOfDrugsAndAlcohol.Add(new States() { ID = "1", State = "true" });
            cboUDA.DataSource = useOfDrugsAndAlcohol;
            cboUDA.DisplayMember = "State";
            cboUDA.ValueMember = "ID";

            var violence = new List<States>();
            violence.Add(new States() { ID = "0", State = "false" });
            violence.Add(new States() { ID = "1", State = "true" });
            cboViolence.DataSource = violence;
            cboViolence.DisplayMember = "State";
            cboViolence.ValueMember = "ID";

        }

        private void setInputValuesFromComboBox()
        {
            inputValues = new string[,] { {"",
                "0",
                cboAlcohol.SelectedValue.ToString(),
                cboABlood.SelectedValue.ToString(),
                cboBlood.SelectedValue.ToString(),
                cboBnG.SelectedValue.ToString(),
                cboCartoon.SelectedValue.ToString(),
                cboCrudeHumor.SelectedValue.ToString(),
                cboDrug.SelectedValue.ToString(),
                cboFantasyViolence.SelectedValue.ToString(),
                cboIntenseViolence.SelectedValue.ToString(),
                cboLanguage.SelectedValue.ToString(),
                cboLyrics.SelectedValue.ToString(),
                cboMatureHumor.SelectedValue.ToString(),
                cboMildBlood.SelectedValue.ToString(),
                cboMildCV.SelectedValue.ToString(),
                cboMildFV.SelectedValue.ToString(),
                cboMildLanguage.SelectedValue.ToString(),
                cboMildLyrics.SelectedValue.ToString(),
                cboMildST.SelectedValue.ToString(),
                cboMildViolence.SelectedValue.ToString(),
                cboNoDescriptors.SelectedValue.ToString(),
                cboNudity.SelectedValue.ToString(),
                cboPartialNudity.SelectedValue.ToString(),
                cboSexualContent.SelectedValue.ToString(),
                cboSexualThemes.SelectedValue.ToString(),
                cboSimulatedGambling.SelectedValue.ToString(),
                cboStrongLanguage.SelectedValue.ToString(),
                cboSSC.SelectedValue.ToString(),
                cboSuggestiveThemes.SelectedValue.ToString(),
                cboUOA.SelectedValue.ToString(),
                cboUDA.SelectedValue.ToString(),
                cboViolence.SelectedValue.ToString(),
                ""

                } };
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            setInputValuesFromComboBox();
            predictionModel.setESRBValues(inputValues);
            predictionModel.StartPrediction();

            startPredicting();
            Thread.Sleep(2000); 
            

        }

        private void startPredicting()
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gettingPercentages();
        }

        private void gettingPercentages()
        {
            decimal probE = decimal.Parse(predictionModel.getProbabilityE(), CultureInfo.InvariantCulture.NumberFormat);
            decimal probET = decimal.Parse(predictionModel.getProbabilityET(), CultureInfo.InvariantCulture.NumberFormat);
            decimal probM = decimal.Parse(predictionModel.getProbabilityM(), CultureInfo.InvariantCulture.NumberFormat);
            decimal probT = decimal.Parse(predictionModel.getProbabilityT(), CultureInfo.InvariantCulture.NumberFormat);

            decimal decProbE = Decimal.Round(probE, 2) * 100;
            decimal decProbET = Decimal.Round(probET, 2) * 100;
            decimal decProbM = Decimal.Round(probM, 2) * 100;
            decimal decProbT = Decimal.Round(probT, 2) * 100;

            labelResult.Text = predictionModel.getResults().ToString();
            label_E.Text = decProbE.ToString() + "%";
            label_ET.Text = decProbET.ToString() + "%";
            label_M.Text = decProbM.ToString() + "%";
            label_T.Text = decProbT.ToString() + "%";
        }

        
    }
}
