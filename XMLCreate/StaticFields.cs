using System;
using System.Collections.Generic;

namespace XMLCreate {
    static class HealthEventType {
        public const string AddDependent = "ADP";
        public const string DeleteDependent = "DDP";
        public const string CancelCoverage = "CCO";
        public const string ChangeHealthPlan = "DEC";
        public const string DependentAddressChange = "DEC";
        public const string ChangePremiumPaymentMethod = "CPP";
        public const string NewEnrollment = "NEN";
        public const string OpenEnrollment = "OEN";
        public const string ContinuedEnrollment = "COE";
        public const string UpdateEnrollment = "UEN";
        public const string COBRANewEnrollment = "CNE";
    }

    public class HealthEventReasonObject {
        public string LongName;
        public int CodeValue;
        public string HealthEventTypeField;

        public HealthEventReasonObject(string LongName, int CodeValue, string HealthEventTypeField) {
            this.LongName = LongName;
            this.CodeValue = CodeValue;
            this.HealthEventTypeField = HealthEventTypeField;
        }
    }

    static class HealthEventReasonObjects {
        public static readonly HealthEventReasonObject BirthPlacement = new HealthEventReasonObject("Birth/placement", 200, HealthEventType.AddDependent);
        public static readonly HealthEventReasonObject CourtOrder = new HealthEventReasonObject("Court Order", 208, HealthEventType.AddDependent);
        public static readonly HealthEventReasonObject Custody = new HealthEventReasonObject("Custody", 202, HealthEventType.AddDependent);
        public static readonly HealthEventReasonObject DomesticPartnerAdd = new HealthEventReasonObject("Domestic Partner Add", 215, HealthEventType.AddDependent);
        public static readonly HealthEventReasonObject DomesticPartnerChildAdd = new HealthEventReasonObject("Domestic Partner Child Add", 216, HealthEventType.AddDependent);
        public static readonly HealthEventReasonObject Economicallydependent = new HealthEventReasonObject("Economically dependent", 203, HealthEventType.AddDependent);
        public static readonly HealthEventReasonObject LossofCoverage = new HealthEventReasonObject("Loss of Coverage", 204, HealthEventType.AddDependent);
        public static readonly HealthEventReasonObject Marriage = new HealthEventReasonObject("Marriage", 201, HealthEventType.AddDependent);
        public static readonly HealthEventReasonObject MedicallyDisabled = new HealthEventReasonObject("Medically Disabled", 210, HealthEventType.AddDependent);
        public static readonly HealthEventReasonObject NewContractingMedicallyDisabled = new HealthEventReasonObject("New Contracting - Medically Disabled", 218, HealthEventType.AddDependent);
        public static readonly HealthEventReasonObject OffpayOpenEnrollment = new HealthEventReasonObject("Off pay Open Enrollment", 207, HealthEventType.AddDependent);
        public static readonly HealthEventReasonObject ReturnfromMilitaryLeave = new HealthEventReasonObject("Return from Military Leave", 205, HealthEventType.AddDependent);
        public static readonly HealthEventReasonObject SpecialEnrollmentDependent = new HealthEventReasonObject("Special Enrollment Dependent", 213, HealthEventType.AddDependent);
        public static readonly HealthEventReasonObject AppealDenied = new HealthEventReasonObject("Appeal denied", 507, HealthEventType.CancelCoverage);
        public static readonly HealthEventReasonObject CancelPermSeparation = new HealthEventReasonObject("Cancel: Perm Separation", 515, HealthEventType.CancelCoverage);
        public static readonly HealthEventReasonObject CancelPASchSiteChg = new HealthEventReasonObject("Cancel; PA/Sch Site Chg", 529, HealthEventType.CancelCoverage);
        public static readonly HealthEventReasonObject ChangeinApptOutsideBU = new HealthEventReasonObject("Change in appt, outside b/u", 501, HealthEventType.CancelCoverage);
        public static readonly HealthEventReasonObject InsufficientHours = new HealthEventReasonObject("Insufficient Hours", 500, HealthEventType.CancelCoverage);
        public static readonly HealthEventReasonObject LayoffCancel = new HealthEventReasonObject("Layoff Cancel", 516, HealthEventType.CancelCoverage);
        public static readonly HealthEventReasonObject MilitaryLeave = new HealthEventReasonObject("Military Leave", 534, HealthEventType.CancelCoverage);
        public static readonly HealthEventReasonObject OffPayStatusCancel = new HealthEventReasonObject("Off Pay Status Cancel", 533, HealthEventType.CancelCoverage);
        public static readonly HealthEventReasonObject ReinstatementNonPERS = new HealthEventReasonObject("Reinstatement (Non-PERS)", 535, HealthEventType.CancelCoverage);
        public static readonly HealthEventReasonObject SubscriberDeath = new HealthEventReasonObject("Subscriber Death", 526, HealthEventType.CancelCoverage);
        public static readonly HealthEventReasonObject Subscriberrequest = new HealthEventReasonObject("Subscriber request", 505, HealthEventType.CancelCoverage);
        public static readonly HealthEventReasonObject SubscriberRequestCOBRA = new HealthEventReasonObject("Subscriber Request - COBRA", 536, HealthEventType.CancelCoverage);
        public static readonly HealthEventReasonObject TimebaseTenureChg = new HealthEventReasonObject("Time base/tenure chg", 502, HealthEventType.CancelCoverage);
        public static readonly HealthEventReasonObject UpdateCBUBenefits = new HealthEventReasonObject("Update CBU Benefits", 836, HealthEventType.CancelCoverage);
        public static readonly HealthEventReasonObject Associationmembership = new HealthEventReasonObject("Association membership", 403, HealthEventType.ChangeHealthPlan);
        public static readonly HealthEventReasonObject ChangePlanduetoEligibilityZIPChange = new HealthEventReasonObject("Change Plan due to Eligibility ZIP Change", 412, HealthEventType.ChangeHealthPlan);
        public static readonly HealthEventReasonObject Move = new HealthEventReasonObject("Move", 402, HealthEventType.ChangeHealthPlan);
        public static readonly HealthEventReasonObject OffPayduringOpenEnrollment = new HealthEventReasonObject("Off Pay during Open Enrollment", 401, HealthEventType.ChangeHealthPlan);
        public static readonly HealthEventReasonObject Outofassociationplan = new HealthEventReasonObject("Out of association plan", 404, HealthEventType.ChangeHealthPlan);
        public static readonly HealthEventReasonObject SpecialEnrollmentChangeHealthPlan = new HealthEventReasonObject("Special Enrollment - Change Health Plan", 405, HealthEventType.ChangeHealthPlan);
        public static readonly HealthEventReasonObject ChgToDeductFMLA = new HealthEventReasonObject("Chg to deduct-FMLA", 715, HealthEventType.ChangePremiumPaymentMethod);
        public static readonly HealthEventReasonObject ChgToDeductRetirement = new HealthEventReasonObject("Chgto deduct-Retirement", 716, HealthEventType.ChangePremiumPaymentMethod);
        public static readonly HealthEventReasonObject ChgToDeductReturnToWork = new HealthEventReasonObject("Chg to deduct-Return to Work", 712, HealthEventType.ChangePremiumPaymentMethod);
        public static readonly HealthEventReasonObject CSUInactive = new HealthEventReasonObject("CSU Inactive", 708, HealthEventType.ChangePremiumPaymentMethod);
        public static readonly HealthEventReasonObject InsufficientEarnings = new HealthEventReasonObject("Insufficient earnings", 709, HealthEventType.ChangePremiumPaymentMethod);
        public static readonly HealthEventReasonObject LOA = new HealthEventReasonObject("LOA", 704, HealthEventType.ChangePremiumPaymentMethod);
        public static readonly HealthEventReasonObject PendingNDI = new HealthEventReasonObject("Pending NDI", 710, HealthEventType.ChangePremiumPaymentMethod);
        public static readonly HealthEventReasonObject PIOffpay = new HealthEventReasonObject("PI/ off pay", 706, HealthEventType.ChangePremiumPaymentMethod);
        public static readonly HealthEventReasonObject Suspension = new HealthEventReasonObject("Suspension", 707, HealthEventType.ChangePremiumPaymentMethod);
        public static readonly HealthEventReasonObject WorkerCompClaimPending = new HealthEventReasonObject("Worker Comp/Claim Pending", 705, HealthEventType.ChangePremiumPaymentMethod);
        public static readonly HealthEventReasonObject COBRADeathOfEmployee = new HealthEventReasonObject("COBRA Death of Employee", 134, HealthEventType.COBRANewEnrollment);
        public static readonly HealthEventReasonObject COBRADepContSubonMedicare = new HealthEventReasonObject("COBRA Dep Cont-Sub on Medicare", 135, HealthEventType.COBRANewEnrollment);
        public static readonly HealthEventReasonObject COBRADivSepMvFromHousehold = new HealthEventReasonObject("COBRA Div/Sep/Mv from Household", 133, HealthEventType.COBRANewEnrollment);
        public static readonly HealthEventReasonObject COBRALossOfDependentStatus = new HealthEventReasonObject("COBRA Loss of Dependent Status", 136, HealthEventType.COBRANewEnrollment);
        public static readonly HealthEventReasonObject COBRALossOfEmployment = new HealthEventReasonObject("COBRA Loss of Employment", 132, HealthEventType.COBRANewEnrollment);
        public static readonly HealthEventReasonObject COBRANewContractAgencyDep = new HealthEventReasonObject("COBRA New Contract Agency Dep", 140, HealthEventType.COBRANewEnrollment);
        public static readonly HealthEventReasonObject COBRANewContractAgencySub = new HealthEventReasonObject("COBRA New Contract Agency Sub", 139, HealthEventType.COBRANewEnrollment);
        public static readonly HealthEventReasonObject COBRAReductioninHours = new HealthEventReasonObject("COBRA Reduction in Hours", 131, HealthEventType.COBRANewEnrollment);
        public static readonly HealthEventReasonObject PendingRetirement = new HealthEventReasonObject("Pending Retirement", 119, HealthEventType.ContinuedEnrollment);
        public static readonly HealthEventReasonObject PendingRetirementDeferredRetirees = new HealthEventReasonObject("Pending Retirement - Deferred Retirees", 169, HealthEventType.ContinuedEnrollment);
        public static readonly HealthEventReasonObject ReEnrollSESPAFFPOSurvivor = new HealthEventReasonObject("Re-enroll SES/PA FFPO Survivor", 146, HealthEventType.ContinuedEnrollment);
        public static readonly HealthEventReasonObject TwentyThreeYearoldDelete = new HealthEventReasonObject("23 year old delete", 301, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject ChangeOfCustody = new HealthEventReasonObject("Change of custody", 312, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject DeathofDependent = new HealthEventReasonObject("Death of Dependent", 300, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject Divorce = new HealthEventReasonObject("Divorce", 302, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject DomesticPartnerChildTerm = new HealthEventReasonObject("Domestic Partner Child Term", 319, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject DomesticPartnerTerm = new HealthEventReasonObject("Domestic Partner Term", 318, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject EnrollOwnRightDependent = new HealthEventReasonObject("Enroll Own Right Dependent", 304, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject Gainsothercoverage = new HealthEventReasonObject("Gains other coverage", 307, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject Ineligibledependent = new HealthEventReasonObject("Ineligible dependent", 306, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject Legalseparation = new HealthEventReasonObject("Legal separation", 308, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject Losseconomicdependence = new HealthEventReasonObject("Loss economic dependence", 310, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject MarriageofDependentChild = new HealthEventReasonObject("Marriage of Dependent Child", 303, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject MilitaryDelDependent = new HealthEventReasonObject("Military - Del Dependent", 309, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject NoLongerCertifiable = new HealthEventReasonObject("No longer certifiable", 305, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject OptionalDelete = new HealthEventReasonObject("Optional Delete", 311, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject VacatesHousehold = new HealthEventReasonObject("Vacates household", 313, HealthEventType.DeleteDependent);
        public static readonly HealthEventReasonObject AddressUpdate = new HealthEventReasonObject("Address Update", 900, HealthEventType.DependentAddressChange);
        public static readonly HealthEventReasonObject BU06PICadetNewEnroll = new HealthEventReasonObject("BU 06 PI Cadet New Enroll", 153, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject EnrollLessHalftimeEmp = new HealthEventReasonObject("Enroll < halftime Emp", 148, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject EnrollOwnrightEmployees = new HealthEventReasonObject("Enroll Own right Employees", 108, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject LateorLossofCoverageEmp = new HealthEventReasonObject("Late or Loss of Coverage (Emp)", 101, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject LayoffEnrollDirectPay = new HealthEventReasonObject("Layoff: Enroll Direct Pay", 123, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject MilitaryNewEnrollment = new HealthEventReasonObject("Military - New Enrollment", 103, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject NCEEEnrollLessHalftimeEmp = new HealthEventReasonObject("NC EE Enroll < halftime Emp", 150, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject NewContractingEmployee = new HealthEventReasonObject("New Contracting Employee", 115, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject NewContractingLOA = new HealthEventReasonObject("New Contracting LOA", 118, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject NewcontractingSurvivorwithoutBenefits = new HealthEventReasonObject("New contracting Survivor without Benefits", 163, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject OffPayDuringOE = new HealthEventReasonObject("Off Pay during O/E", 111, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject OffPayeligiblePI = new HealthEventReasonObject("Off Pay eligible PI", 107, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject ReEmployment = new HealthEventReasonObject("Re-employment", 167, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject Reinstatement = new HealthEventReasonObject("Reinstatement", 102, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject ReturnfromOffPayStatus = new HealthEventReasonObject("Return from Off Pay Status", 160, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject SpecialEnrollmentEmployees = new HealthEventReasonObject("Special Enrollment Employees", 129, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject StateRetireeDentalEnrollment = new HealthEventReasonObject("State Retiree - Dental Enrollment", 166, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject STRSSurvivorNoAllowance = new HealthEventReasonObject("STRS Survivor No Allowance", 149, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject SurvBenefitsPaidbyER = new HealthEventReasonObject("Surv Benefits Paid by ER", 145, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject SurvivorWithoutBenefits = new HealthEventReasonObject("Survivor Without Benefits", 128, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject TimeBaseTenure = new HealthEventReasonObject("Time Base & Tenure", 100, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject TimeBaseTenureHours = new HealthEventReasonObject("Time Base, Tenure, Hours", 106, HealthEventType.NewEnrollment);
        public static readonly HealthEventReasonObject EnrolledintoFlexElect = new HealthEventReasonObject("Enrolled into Flex Elect", 503, HealthEventType.OpenEnrollment);
        public static readonly HealthEventReasonObject OECancelCoverage = new HealthEventReasonObject("OE Cancel Coverage", 530, HealthEventType.OpenEnrollment);
        public static readonly HealthEventReasonObject OEEnrollLessHalftimeEmpNewEnrollment = new HealthEventReasonObject("OE Enroll < halftime Emp New Enrollment", 170, HealthEventType.OpenEnrollment);
        public static readonly HealthEventReasonObject OpenEnrollmentAddDep = new HealthEventReasonObject("Open Enrollment Add Dep", 206, HealthEventType.OpenEnrollment);
        public static readonly HealthEventReasonObject OpenEnrollmentChangeHealthPlan = new HealthEventReasonObject("Open Enrollment Change Health Plan", 400, HealthEventType.OpenEnrollment);
        public static readonly HealthEventReasonObject OpenEnrollmentDeleteDependent = new HealthEventReasonObject("Open Enrollment Delete Dependent", 320, HealthEventType.OpenEnrollment);
        public static readonly HealthEventReasonObject OpenEnrollmentEmployeesNewEnrollment = new HealthEventReasonObject("Open Enrollment Employees New Enrollment", 104, HealthEventType.OpenEnrollment);
        //public static readonly HealthEventReasonObject RecertificationofDisabledDependent = new HealthEventReasonObject("Recertification of Disabled Dependent", 906, HealthEventType.RecertifyDependent);
        public static readonly HealthEventReasonObject CancelEligibilityZIPEmployer = new HealthEventReasonObject("Cancel Eligibility ZIP - Employer", 481, HealthEventType.UpdateEnrollment);
        public static readonly HealthEventReasonObject ChangeEligibilityZIPEmployer = new HealthEventReasonObject("Change Eligibility ZIP - Employer", 480, HealthEventType.UpdateEnrollment);
        public static readonly HealthEventReasonObject ChangeMedicalGroup = new HealthEventReasonObject("Change Medical Group", 904, HealthEventType.UpdateEnrollment);
        public static readonly HealthEventReasonObject OptinVesting = new HealthEventReasonObject("Opt in Vesting", 908, HealthEventType.UpdateEnrollment);
        public static readonly HealthEventReasonObject OptoutVesting = new HealthEventReasonObject("Opt out Vesting", 909, HealthEventType.UpdateEnrollment);

        public static List<HealthEventReasonObject> GetAllObjects() {
            return new List<HealthEventReasonObject>() {
                BirthPlacement, CourtOrder, Custody, DomesticPartnerAdd, DomesticPartnerChildAdd,
                Economicallydependent, LossofCoverage, Marriage, MedicallyDisabled, NewContractingMedicallyDisabled,
                OffpayOpenEnrollment, ReturnfromMilitaryLeave, SpecialEnrollmentDependent, AppealDenied,
                CancelPermSeparation, CancelPASchSiteChg, ChangeinApptOutsideBU, InsufficientHours,
                LayoffCancel, MilitaryLeave, OffPayStatusCancel, ReinstatementNonPERS, SubscriberDeath,
                Subscriberrequest, SubscriberRequestCOBRA, TimebaseTenureChg, UpdateCBUBenefits,
                Associationmembership, ChangePlanduetoEligibilityZIPChange, Move,
                OffPayduringOpenEnrollment, Outofassociationplan, SpecialEnrollmentChangeHealthPlan,
                ChgToDeductFMLA, ChgToDeductRetirement, ChgToDeductReturnToWork, CSUInactive,
                InsufficientEarnings, LOA, PendingNDI, PIOffpay, Suspension, WorkerCompClaimPending,
                COBRADeathOfEmployee, COBRADepContSubonMedicare, COBRADivSepMvFromHousehold,
                COBRALossOfDependentStatus, COBRALossOfEmployment, COBRANewContractAgencyDep,
                COBRANewContractAgencySub, COBRAReductioninHours, PendingRetirement,
                PendingRetirementDeferredRetirees, ReEnrollSESPAFFPOSurvivor, TwentyThreeYearoldDelete,
                ChangeOfCustody, DeathofDependent, Divorce, DomesticPartnerChildTerm, DomesticPartnerTerm,
                EnrollOwnRightDependent, Gainsothercoverage, Ineligibledependent, Legalseparation,
                Losseconomicdependence, MarriageofDependentChild, MilitaryDelDependent,
                NoLongerCertifiable, OptionalDelete, VacatesHousehold, AddressUpdate,
                BU06PICadetNewEnroll, EnrollLessHalftimeEmp, EnrollOwnrightEmployees,
                LateorLossofCoverageEmp, LayoffEnrollDirectPay, MilitaryNewEnrollment,
                NCEEEnrollLessHalftimeEmp, NewContractingEmployee, NewContractingLOA,
                NewcontractingSurvivorwithoutBenefits, OffPayDuringOE, OffPayeligiblePI, ReEmployment,
                Reinstatement, ReturnfromOffPayStatus, SpecialEnrollmentEmployees,
                StateRetireeDentalEnrollment, STRSSurvivorNoAllowance, SurvBenefitsPaidbyER,
                SurvivorWithoutBenefits, TimeBaseTenure, TimeBaseTenureHours, EnrolledintoFlexElect,
                OECancelCoverage, OEEnrollLessHalftimeEmpNewEnrollment, OpenEnrollmentAddDep,
                OpenEnrollmentChangeHealthPlan, OpenEnrollmentDeleteDependent, OpenEnrollmentEmployeesNewEnrollment,
                CancelEligibilityZIPEmployer, ChangeEligibilityZIPEmployer, ChangeMedicalGroup,
                OptinVesting, OptoutVesting};
        }
    }

    public class MedicalGroupObject {
        public static string GroupName;
        public static string GroupNumber;

        public MedicalGroupObject(string name, string number) {
            GroupName = name;
            GroupNumber = number;
        }
    }

    static class MedicalGroups {
        public static MedicalGroupObject CertificatedGroupA =
            new MedicalGroupObject("CERTIFICATED - GROUP A", "001");
        public static MedicalGroupObject CertificatedMgmtGroupA =
            new MedicalGroupObject("CERTIFICATED MGMT-GROUP A", "003");
        public static MedicalGroupObject SEIULocal715 =
            new MedicalGroupObject("SEIU LOCAL 715", "006");
        public static MedicalGroupObject SEAChapter266GroupA =
            new MedicalGroupObject("CSEA CHAPTER 266-GROUP A", "005");
        public static MedicalGroupObject Unrepresented =
            new MedicalGroupObject("UNREPRESENTED", "007");
        public static MedicalGroupObject CertificatedGroupB =
            new MedicalGroupObject("CERTIFICATED - GROUP B", "002");
        public static MedicalGroupObject BoardOfTrustees =
            new MedicalGroupObject("BOARD OF TRUSTEES", "701");
        public static MedicalGroupObject CertificatedMgmtGroupB =
            new MedicalGroupObject("CERTIFICATED MGMT-GROUP B", "004");
    }

    static class AddressType {
        public const string MailingAddress = "MAI";
        public const string PhysicalAddress = "PHY";
    }

    static class StateCode {
        public const string Connecticut = "CT";
        public const string Delaware = "DE";
        public const string DistrictofColumbia = "DC";
        public const string FederatedStatesofMicronesia = "FM";
        public const string Florida = "FL";
        public const string Georgia = "GA";
        public const string Guam = "GU";
        public const string Hawaii = "HI";
        public const string Idaho = "ID";
        public const string Illinois = "IL";
        public const string Indiana = "IN";
        public const string Iowa = "IA";
        public const string Kansas = "KS";
        public const string Kentucky = "KY";
        public const string Louisiana = "LA";
        public const string Maine = "ME";
        public const string MarshallIslands = "MH";
        public const string Maryland = "MD";
        public const string Massachusetts = "MA";
        public const string Michigan = "MI";
        public const string Minnesota = "MN";
        public const string Mississippi = "MS";
        public const string Missouri = "MO";
        public const string Montana = "MT";
        public const string Washington = "WA";
        public const string WestVirginia = "WV";
        public const string Alabama = "AL";
        public const string Alaska = "AK";
        public const string AmericanSamoa = "AS";
        public const string Arizona = "AZ";
        public const string Arkansas = "AR";
        public const string ArmedForcesEurope = "AE";
        public const string ArmedForcesPacific = "AP";
        public const string ArmedForcestheAmericas = "AA";
        public const string California = "CA";
        public const string Colorado = "CO";
        public const string Nebraska = "NE";
        public const string Nevada = "NV";
        public const string NewHampshire = "NH";
        public const string NewJersey = "NJ";
        public const string NewMexico = "NM";
        public const string NewYork = "NY";
        public const string NorthCarolina = "NC";
        public const string NorthDakota = "ND";
        public const string NorthMarianaIslands = "MP";
        public const string Ohio = "OH";
        public const string Oklahoma = "OK";
        public const string Oregon = "OR";
        public const string Palau = "PW";
        public const string Pennsylvania = "PA";
        public const string PuertoRico = "PR";
        public const string RhodeIsland = "RI";
        public const string SouthCarolina = "SC";
        public const string SouthDakota = "SD";
        public const string Tennessee = "TN";
        public const string Texas = "TX";
        public const string Utah = "UT";
        public const string Vermont = "VT";
        public const string VirginIslands = "VI";
        public const string Virginia = "VA";
        public const string Wisconsin = "WI";
        public const string Wyoming = "WY";
    }

    static class CountryCodes {
        public const string UnitedStates = "US";
        public const string Canada = "CA";
        public const string Mexico = "MX";
        public const string Afghanistan = "AF";
        public const string Albania = "AL";
        public const string Algeria = "DZ";
        public const string AmericanSamoa = "AS";
        public const string Andorra = "AD";
        public const string Angola = "AO";
        public const string Anguilla = "AI";
        public const string Antarctica = "AQ";
        public const string AntiguaandBarbuda = "AG";
        public const string Argentina = "AR";
        public const string Armenia = "AM";
        public const string Aruba = "AW";
        public const string Australia = "AU";
        public const string Austria = "AT";
        public const string Azerbaijan = "AZ";
        public const string Bahamas = "BS";
        public const string Bahrain = "BH";
        public const string Bangladesh = "BD";
        public const string Barbados = "BB";
        public const string Belarus = "BY";
        public const string Belgium = "BE";
        public const string Colombia = "CO";
        public const string Comoros = "KM";
        public const string Congo = "CG";
        public const string CookIslands = "CK";
        public const string CostaRica = "CR";
        public const string Croatia = "HR";
        public const string Cuba = "CU";
        public const string Cyprus = "CY";
        public const string CzechRepublic = "CZ";
        public const string TheDemocraticRepublicoftheCongo = "CD";
        public const string Denmark = "DK";
        public const string Djibouti = "DJ";
        public const string Dominica = "DM";
        public const string DominicanRepublic = "DO";
        public const string Ecuador = "EC";
        public const string Egypt = "EG";
        public const string ElSalvador = "SV";
        public const string EquatorialGuinea = "GQ";
        public const string Eritrea = "ER";
        public const string Estonia = "EE";
        public const string Ethiopia = "ET";
        public const string FalklandIslands = "FK";
        public const string FaroeIslands = "FO";
        public const string Fiji = "FJ";
        public const string Finland = "FI";
        public const string India = "IN";
        public const string Indonesia = "ID";
        public const string Iran = "IR";
        public const string Iraq = "IQ";
        public const string Ireland = "IE";
        public const string IsleOfMan = "IM";
        public const string Israel = "IL";
        public const string Italy = "IT";
        public const string IvoryCoast = "CI";
        public const string Jamaica = "JM";
        public const string JanMayen = "SJ";
        public const string Japan = "JP";
        public const string Jersey = "JE";
        public const string Jordan = "JO";
        public const string Kazakhstan = "KZ";
        public const string Kenya = "KE";
        public const string Kiribati = "KI";
        public const string Kuwait = "KW";
        public const string Kyrgyzstan = "KG";
        public const string Laos = "LA";
        public const string Latvia = "LV";
        public const string Lebanon = "LB";
        public const string Lesotho = "LS";
        public const string Liberia = "LR";
        public const string Libya = "LY";
        public const string Liechtenstein = "LI";
        public const string Nepal = "NP";
        public const string Netherlands = "NL";
        public const string NetherlandsAntilles = "AN";
        public const string NewCaledonia = "NC";
        public const string NewZealand = "NZ";
        public const string Nicaragua = "NI";
        public const string Niger = "NE";
        public const string Nigeria = "NG";
        public const string Niue = "NU";
        public const string NorfolkIsland = "NF";
        public const string NorthKorea = "KP";
        public const string NorthernMarianaIslands = "MP";
        public const string Norway = "NO";
        public const string Oman = "OM";
        public const string Pakistan = "PK";
        public const string Panama = "PA";
        public const string PapuaNewGuinea = "PG";
        public const string Paraguay = "PY";
        public const string Peru = "PE";
        public const string Philippines = "PH";
        public const string PitcairnIsland = "PN";
        public const string Poland = "PL";
        public const string Portugal = "PT";
        public const string PuertoRico = "PR";
        public const string Qatar = "QA";
        public const string RepublicOfSouthKorea = "KR";
        public const string Swaziland = "SZ";
        public const string Sweden = "SE";
        public const string Switzerland = "CH";
        public const string Syria = "SY";
        public const string Taiwan = "TW";
        public const string Tajikistan = "TJ";
        public const string Tanzania = "TZ";
        public const string Thailand = "TH";
        public const string Togo = "TG";
        public const string Tokelau = "TK";
        public const string Tonga = "TO";
        public const string TrinidadandTobago = "TT";
        public const string Tunisia = "TN";
        public const string Turkey = "TR";
        public const string Belize = "BZ";
        public const string Benin = "BJ";
        public const string Bermuda = "BM";
        public const string Bhutan = "BT";
        public const string Bolivia = "BO";
        public const string BosniaHerzegovina = "BA";
        public const string Botswana = "BW";
        public const string BouvetIsland = "BV";
        public const string Brazil = "BR";
        public const string BritishIndianOceanTerr = "IO";
        public const string Brunei = "BN";
        public const string Bulgaria = "BG";
        public const string BurkinaFaso = "BF";
        public const string Burundi = "BI";
        public const string Cambodia = "KH";
        public const string Cameroon = "CM";
        public const string CapeVerde = "CV";
        public const string CaymanIslands = "KY";
        public const string CentralAfricanRepublic = "CF";
        public const string Chad = "TD";
        public const string Chile = "CL";
        public const string China = "CN";
        public const string ChristmasIsland = "CX";
        public const string CocosIslands = "CC";
        public const string France = "FR";
        public const string FrenchGuiana = "GF";
        public const string FrenchPolynesia = "PF";
        public const string Gabon = "GA";
        public const string Gambia = "GM";
        public const string Georgia = "GE";
        public const string Germany = "DE";
        public const string Ghana = "GH";
        public const string Gibraltar = "GI";
        public const string Greece = "GR";
        public const string Greenland = "GL";
        public const string Grenada = "GD";
        public const string Guadeloupe = "GP";
        public const string Guam = "GU";
        public const string Guatemala = "GT";
        public const string Guernsey = "GG";
        public const string Guinea = "GN";
        public const string GuineaBissau = "GW";
        public const string Guyana = "GY";
        public const string Haiti = "HT";
        public const string HeardMcDonaldIslands = "HM";
        public const string Honduras = "HN";
        public const string HongKong = "HK";
        public const string Hungary = "HU";
        public const string Iceland = "IS";
        public const string Lithuania = "LT";
        public const string Luxembourg = "LU";
        public const string Macau = "MO";
        public const string Macedonia = "MK";
        public const string Madagascar = "MG";
        public const string Malawi = "MW";
        public const string Malaysia = "MY";
        public const string Maldives = "MV";
        public const string Mali = "ML";
        public const string Malta = "MT";
        public const string MarshallIslands = "MH";
        public const string Martinique = "MQ";
        public const string Mauritania = "MR";
        public const string Mauritius = "MU";
        public const string Mayotte = "YT";
        public const string Micronesia = "FM";
        public const string Moldova = "MD";
        public const string Monaco = "MC";
        public const string Mongolia = "MN";
        public const string Montenegro = "ME";
        public const string Montserrat = "MS";
        public const string Morocco = "MA";
        public const string Mozambique = "MZ";
        public const string Myanmar = "MM";
        public const string Namibia = "NA";
        public const string Nauru = "NR";
        public const string Reunion = "RE";
        public const string Romania = "RO";
        public const string Russia = "RU";
        public const string Rwanda = "RW";
        public const string SanMarino = "SM";
        public const string SaoTomeandPrincipe = "ST";
        public const string SaudiArabia = "SA";
        public const string Senegal = "SN";
        public const string Serbia = "RS";
        public const string Seychelles = "SC";
        public const string SierraLeone = "SL";
        public const string Singapore = "SG";
        public const string Slovakia = "SK";
        public const string Slovenia = "SI";
        public const string SolomonIslands = "SB";
        public const string Somalia = "SO";
        public const string SouthAfrica = "ZA";
        public const string Spain = "ES";
        public const string SriLanka = "LK";
        public const string StHelena = "SH";
        public const string StKittsandNevis = "KN";
        public const string StLucia = "LC";
        public const string StPierreandMiquelon = "PM";
        public const string StVincentandGrenadines = "VC";
        public const string Sudan = "SD";
        public const string Suriname = "SR";
        public const string Vietnam = "VN";
        public const string VirginIslandsBritish = "VG";
        public const string VirginIslandsUS = "VI";
        public const string WallisandFUTUNA = "WF";
        public const string WesternSahara = "EH";
        public const string WesternSamoa = "WS";
        public const string Yemen = "YE";
        public const string Zambia = "ZM";
        public const string Zimbabwe = "ZW";
    }

    static class CountyCodes {
        public const string Alameda = "001";
        public const string Alpine = "003";
        public const string Amador = "005";
        public const string Butte = "007";
        public const string Calaveras = "009";
        public const string Colusa = "011";
        public const string ContraCosta = "013";
        public const string DelNorte = "015";
        public const string ElDorado = "017";
        public const string Fresno = "019";
        public const string Glenn = "021";
        public const string Humboldt = "023";
        public const string Imperial = "025";
        public const string Inyo = "027";
        public const string Kern = "029";
        public const string Kings = "031";
        public const string Lake = "033";
        public const string Lassen = "035";
        public const string LosAngeles = "037";
        public const string Madera = "039";
        public const string Marin = "041";
        public const string Mariposa = "043";
        public const string Mendocino = "045";
        public const string Merced = "047";
        public const string Modoc = "049";
        public const string Sutter = "101";
        public const string Tehama = "103";
        public const string Trinity = "105";
        public const string Tulare = "107";
        public const string Tuolumne = "109";
        public const string Ventura = "111";
        public const string Yolo = "113";
        public const string Yuba = "115";
        public const string OutofState = "000";
        public const string Mono = "051";
        public const string Monterey = "053";
        public const string Napa = "055";
        public const string Nevada = "057";
        public const string Orange = "059";
        public const string Placer = "061";
        public const string Plumas = "063";
        public const string Riverside = "065";
        public const string Sacramento = "067";
        public const string SanBenito = "069";
        public const string SanBernardino = "071";
        public const string SanDiego = "073";
        public const string SanFrancisco = "075";
        public const string SanJoaquin = "077";
        public const string SanLuisObispo = "079";
        public const string SanMateo = "081";
        public const string SantaBarbara = "083";
        public const string SantaClara = "085";
        public const string SantaCruz = "087";
        public const string Shasta = "089";
        public const string Sierra = "091";
        public const string Siskiyou = "093";
        public const string Solano = "095";
        public const string Sonoma = "097";
        public const string Stanislaus = "099";
        public const string FirstDistrictSF = "100";
        public const string SecondDistrictLA = "110";
        public const string SecondSubDistrictVentura = "117";
        public const string ThirdDistrictSac = "120";
        public const string FourthDistrictSanDiego = "130";
        public const string FourthSubDistrictRiverside = "131";
        public const string FourthSubDistrictSantaAna = "132";
        public const string FifthDistrictFresno = "140";
        public const string SixthDistrictSantaClara = "150";
    }

    static class DependentRelationship {
        public const string Spouse = "SPO";
        public const string DomesticPartner = "DP";
        public const string Brother = "BRO";
        public const string Sister = "SIS";
        public const string Niece = "NIE";
        public const string Nephew = "NEP";
        public const string Grandchild = "GC";
        public const string Child = "CHI";
        public const string StepChild = "SC";
        public const string DomesticPartnerChild = "DPC";
        public const string StepGrandChild = "SG";
        public const string GreatGrandChild = "GG";
        public const string Cousin = "COU";
        public const string OtherPerson = "OP";
        public const string AdoptedChild = "ADC";
    }

    static class DependentType {
        public const string DependentNaturalBornChild = "DBC";
        public const string DependentAdoptedChild = "DAC";
        public const string EconomicallyDependentChild = "EDC";
        public const string Spouse = "SPO";
        public const string StepChild = "STC";
        public const string DomesticPartner = "DP";
        public const string DomesticPartnerChild = "DPC";
        public const string Sibling = "SIB";
    }

    /// <summary>
    /// I don't know what I'm doing here. Just use Dependent Relationship and Dependent Type.
    /// </summary>
    static class DependentTypeObject {
        public static readonly KeyValuePair<String, List<String>> DependentNaturalBornChild = 
            new KeyValuePair<string, List<string>>(DependentType.DependentNaturalBornChild, new List<string>() { DependentRelationship.Child });

        public static readonly KeyValuePair<String, List<String>> DependentAdoptedChild =
            new KeyValuePair<string, List<string>>(DependentType.DependentAdoptedChild, new List<string>() { DependentRelationship.Child });

        public static readonly KeyValuePair<String, List<String>> EconomicallyDepndentChild =
            new KeyValuePair<string, List<string>>(DependentType.EconomicallyDependentChild, new List<string>() {
                DependentRelationship.Child,
                DependentRelationship.Niece,
                DependentRelationship.Nephew,
                DependentRelationship.Grandchild,
                DependentRelationship.StepChild,
                DependentRelationship.DomesticPartnerChild,
                DependentRelationship.StepGrandChild,
                DependentRelationship.GreatGrandChild
            });

        public static readonly KeyValuePair<String, List<String>> Spouse =
            new KeyValuePair<string, List<string>>(DependentType.Spouse, new List<string>() { DependentRelationship.Spouse });

        public static readonly KeyValuePair<String, List<String>> StepChild =
            new KeyValuePair<string, List<string>>(DependentType.StepChild, new List<string>() { DependentRelationship.Child });

        public static readonly KeyValuePair<String, List<String>> DomesticPartner =
                    new KeyValuePair<string, List<string>>(DependentType.DomesticPartner, new List<string>() { DependentRelationship.DomesticPartner });

        public static readonly KeyValuePair<String, List<String>> DomesticPartnerChild =
                            new KeyValuePair<string, List<string>>(DependentType.DomesticPartnerChild, new List<string>() { DependentRelationship.Child });

        public static readonly KeyValuePair<String, List<String>> Sibling =
                            new KeyValuePair<string, List<string>>(DependentType.Sibling, new List<string>() { DependentRelationship.Sister, DependentRelationship.Brother });
    }

    static class IdentificationType {
        public const string SocialSecurityNumber = "SSN";
        public const string CalPERSIndetification = "PID";
    }

    static class RetirementSystem {
        public const string CalSTRS = "STR";
        public const string MilitaryRetirementSystem = "MRS";
        public const string Other = "OTH";
    }

    static class Prefix {
        public const string AssemblyMember = "ASM";
        public const string Chief = "CHI";
        public const string Councilman = "COU";
        public const string Councilwoman = "CCW";
        public const string Dean = "DEA";
        public const string Doctor = "DR";
        public const string Judge = "JUD";
        public const string Mayor = "MAY";
        public const string Miss = "MIS";
        public const string Mister = "MR";
        public const string Mrs = "MRS";
        public const string Ms = "MS";
        public const string President = "PRE";
        public const string Professor = "PRO";
        public const string Senator = "SEN";
        public const string Superintendent = "SUP";
        public const string Supervisor = "SVR";
        public const string TheHonorable = "HON";
        public const string Justice = "JUS";
        public const string ChiefJustice = "CHJ";
    }

    static class Gender {
        public const string Male = "M";
        public const string Female = "F";
        public const string Unknown = "U";
    }

    static class Suffix {
        public const string Senior = "SR";
        public const string Junior = "JR";
        public const string First = "I";
        public const string Second = "II";
        public const string Third = "III";
        public const string Fourth = "IV";
        public const string Fifth = "V";
        public const string PhD = "PHD";
        public const string MD = "MD";
        public const string CPA = "CPA";
        public const string EdD = "EDD";
        public const string Esq = "ESQ";
        public const string DDS = "DDS";
    }

    static class PhoneType {
        public const string Work = "WOR";
        public const string FAX = "FAX";
        public const string TYY = "TYY";
        public const string Cellular = "MOB";
        public const string Home = "HOM";
        public const string Other = "OTR";
    }

    static class COBRAEligibilityBasis {
        public const string COBRAQualifyingSubscriber = "CSB";
        public const string COBRAQualifyingDependent = "CDT";
        public const string COBRAQualifyingNewContracting = "CSC";
        public const string COBRAQualifyingDependentNewContracting = "CDC";
    }

    static class AffiliatedAssociation {
        public const string CaliforniaAssociationsOfHighwayPatrol = "CHP";
        public const string CaliforniaCorrectionalPeaceOfficersAssociation = "CPO";
        public const string PeaceOfficersResearchAssociationOfCalifornia = "POR";
    }

    public class MedicalPlanInfo {
        public string EaseID;
        public string LongName;
        public string PlanCode;

        public MedicalPlanInfo(string EaseID, string LongName, string PlanCode) {
            this.EaseID = EaseID;
            this.LongName = LongName;
            this.PlanCode = PlanCode;
        }
    }

    static class MedicalPlanData {
        public static readonly MedicalPlanInfo AnthemSelectHMO = new MedicalPlanInfo("28LWB6", "Anthem Select HMO", "506");
        public static readonly MedicalPlanInfo AnthemTraditionalHMO = new MedicalPlanInfo("GCENUV", "Anthem Traditional HMO", "509");
        public static readonly MedicalPlanInfo BlueShieldAccessPlus = new MedicalPlanInfo("WGJYAA", "Blue Shield Access +", "525");
        public static readonly MedicalPlanInfo HealthNetSmartCare = new MedicalPlanInfo("KZCU9J", "HealthNet SmartCare", "528");
        public static readonly MedicalPlanInfo Kaiser = new MedicalPlanInfo("8NBVRF", "Kaiser", "533");
        public static readonly MedicalPlanInfo PERSCare = new MedicalPlanInfo("XTQYCJ", "PERSCare", "566");
        public static readonly MedicalPlanInfo PERSChoice = new MedicalPlanInfo("BDEPAH", "PERS Choice", "548");
        public static readonly MedicalPlanInfo PERSSelect = new MedicalPlanInfo("ZP5VED", "PERS Select", "557");
    }

    static class MedicalPlanCodes {
        public static readonly List<MedicalPlanInfo> Plans = new List<MedicalPlanInfo>(){
            MedicalPlanData.AnthemSelectHMO, MedicalPlanData.AnthemTraditionalHMO, MedicalPlanData.BlueShieldAccessPlus,
            MedicalPlanData.HealthNetSmartCare, MedicalPlanData.Kaiser, MedicalPlanData.PERSCare,
            MedicalPlanData.PERSChoice, MedicalPlanData.PERSSelect
        };
    }

    public class CollectiveBargainingUnit {
        public string GroupNumber { get; set; }
        public string GroupName { get; set; }

        public CollectiveBargainingUnit(string name, string number) {
            GroupName = name;
            GroupNumber = number;
        }
    }

    public static class CollectiveBargainingUnits {
        public static CollectiveBargainingUnit CertificatedGroupA =
            new CollectiveBargainingUnit("Certificated Group A", "001");
        public static CollectiveBargainingUnit CertificatedGroupB =
                    new CollectiveBargainingUnit("Certificated Group A", "002");
        public static CollectiveBargainingUnit CertificatedMgmtGroupA =
                    new CollectiveBargainingUnit("Certificated MGMT Group A", "003");
        public static CollectiveBargainingUnit CertificatedMgmtGroupB =
                    new CollectiveBargainingUnit("Certificated MGMT Group B", "004");
        public static CollectiveBargainingUnit CESAChapter266GroupA =
                    new CollectiveBargainingUnit("CESA Chapter 266 Group A", "005");
        public static CollectiveBargainingUnit SEIULocal715 =
                    new CollectiveBargainingUnit("SEIU Local 715", "006");
        public static CollectiveBargainingUnit Unrepresented =
                    new CollectiveBargainingUnit("Unrepresented", "007");
        public static CollectiveBargainingUnit BoardOfTrustees =
            new CollectiveBargainingUnit("Board of Trustees", "701");
        public static CollectiveBargainingUnit Empty = new CollectiveBargainingUnit("", "");

        private static List<string> BoardMembers = new List<string>() { "1092488469", "1145535929", "4884536376"};
        //private static List<string> Unreped = new List<string>() {
        //    "1517073459", "5240314432", "5526734356", "7620240366", "3237809561",
        //    "4284286002", "7318802510", "3593471176", "1272665877", "5939166906",
        //    "5142999363", "7243882506", "5061023360", "5220388112", "4792291435",
        //    "6881756925", "4648275124", "6068391745", "5429531326", "5074822488",
        //    "4506578929", "6746974959", "3859698928", "2391267871", "5480444736",
        //    "3160668847", "1526842720", "4170058818", "6654857961", "2093044848",
        //    "2162857482", "3002448890", "2672079234", "1921100581", "5198009223",
        //    "5898503863", "7335938636", "3341112048", "4496466171", "5305216413",
        //    "2797712260", "8707105812", "4266413200", "5357922170", "3199768682",
        //    "4908229358"};

        public static CollectiveBargainingUnit GetCollectiveBargainingUnit(CensusRow emp) {
            if (Program.Unreped.Contains(emp.CalPERS_ID))
                return Unrepresented;

            if (BoardMembers.Contains(emp.CalPERS_ID))
                return BoardOfTrustees;

            if (emp.JobClass.Contains("CHSTA"))
                return CertificatedGroupA;

            if (emp.JobClass.Contains("CSEA"))
                return CESAChapter266GroupA;

            if (emp.JobClass.Contains("SEIU"))
                return SEIULocal715;

            if (emp.JobClass.Contains("Class"))
                return CertificatedMgmtGroupB;

            if (emp.JobClass.Contains("Cert"))
                return CertificatedMgmtGroupA;

            return Empty;
        } 
    }
}
