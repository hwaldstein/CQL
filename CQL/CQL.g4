grammar CQL;

// Department, Course Number, Is Honors, GenEd, and Session
root: expression 
	     (Source Equals source)? // default to current session
         (OrderBy order)? // default alphabetically by department then numberically by number
         (Limit number)? EOF; // default to show all results

expression: LeftParen expr=expression RightParen #parenExpression
          | left=expression op=And right=expression #andExpression
          | left=expression op=Or right=expression #orExpression
          | atomExpr=atomicExpression #atomExpression
          ; 

atomicExpression: departmentSelectExpression 
                | courseNumberSelectExpression 
                | isHonorsSelectExpression 
                | genEdSelectExpression;

// Atomic Expressions
courseNumberSelectExpression: CourseNumberSelector equivalenceOperator CourseNumber #courseNumberEqualsExpr
                            | CourseNumberSelector membershipOperator LeftBracket CourseNumber (Comma CourseNumber)* RightBracket #courseNumberListExpr
                            | CourseNumberSelector inequalityOperator CourseNumber #courseNumberInqualityExpr
                            ;

departmentSelectExpression: DepartmentSelector equivalenceOperator Department #deptEqualsExpr
                          | DepartmentSelector membershipOperator LeftBracket Department (Comma Department)* RightBracket #deptListExpr
                          ;

genEdSelectExpression: GenEdSelector equivalenceOperator GenEd #genEdEqualsExpr
                     | GenEdSelector membershipOperator LeftBracket GenEd (Comma GenEd)* RightBracket #genEdListExpr
                     ;

isHonorsSelectExpression: IsHonorsSelector equivalenceOperator bool;


// Clauses
source: Season Dash Year #session
	  | Catalog LeftParen Year Dash Year RightParen #catalog
      ;

order: DepartmentSelector Asc #deptAsc
     | DepartmentSelector Desc #deptDesc
     | CourseNumberSelector Asc #courseNumberAsc
	 | CourseNumberSelector Desc #courseNumberDesc
     | IsHonorsSelector Asc #isHonorsAsc
	 | IsHonorsSelector Desc #isHonorsDesc
     | GenEdSelector Asc #genEdAsc
	 | GenEdSelector Desc #genEdDesc
     ;


// Operators
equivalenceOperator: Equals #eq
                   | NotEquals #notEq
                   ;

inequalityOperator: Gt #greaterThan
                  | GtEq #greaterThanOrEqualTo
                  | Lt #lessThan
                  | LtEq #lessThanOrEqualTo
                  ;

membershipOperator: In #in
                  | NotIn #notIn
                  ;

// Constants
bool: True #true
    | False #false
    ;

number: Digit+;


// Lexer Rules
Department: 'ABRD' | 'ACB' | 'ACCT' | 'ACTS' | 'AERO' | 'AFAM' | 'AINS' | 'AMCS' | 'AMST' | 'ANES' | 'ANIM' | 'ANTH' | 'ARAB' | 'ARTE' | 'ARTH' | 'ARTS' | 'ASIA' | 'ASL' | 'ASLE' | 'ASP' | 'ASTR' | 'ATEP' | 'BIOC' | 'BIOL' | 'BIOS' | 'BKAT' | 'BME' | 'BMED' | 'BMS' | 'BUS' | 'CBE' | 'CBH' | 'CCCC' | 'CCP' | 'CDE' | 'CEE' | 'CERM' | 'CHEM' | 'CHIN' | 'CINE' | 'CL' | 'CLAS' | 'CLSA' | 'CLSG' | 'CLSL' | 'CNW' | 'COMM' | 'CPH' | 'CRIM' | 'CS' | 'CSD' | 'CSI' | 'CTS' | 'CW' | 'DANC' | 'DENT' | 'DERM' | 'DIET' | 'DPA' | 'DPH' | 'DRAW' | 'DSGN' | 'DST' | 'EALL' | 'ECE' | 'ECON' | 'EDTL' | 'EES' | 'EHOP' | 'EM' | 'EMTP' | 'ENDO' | 'ENGL' | 'ENGR' | 'ENNM' | 'ENTR' | 'ENVS' | 'EPID' | 'EPLS' | 'ESL' | 'EVNT' | 'FAM' | 'FAMD' | 'FIN' | 'FPC' | 'FREN' | 'FRRB' | 'GENE' | 'GEOG' | 'GHS' | 'GRAD' | 'GRMN' | 'GSND' | 'GWSS' | 'HHP' | 'HIST' | 'HMP' | 'HONR' | 'HPAS' | 'HRTS' | 'IALL' | 'IAP' | 'IBA' | 'IE' | 'IGPI' | 'IIEP' | 'IM' | 'IMMU' | 'INTD' | 'INTM' | 'IS' | 'ITAL' | 'IWP' | 'IYWS' | 'JMC' | 'JPNS' | 'KORE' | 'LAS' | 'LATH' | 'LATS' | 'LAW' | 'LING' | 'LLS' | 'LS' | 'LWAB' | 'MATH' | 'MBA' | 'MCB' | 'MDVL' | 'ME' | 'MED' | 'MGMT' | 'MICR' | 'MILS' | 'MKTG' | 'MPB' | 'MSCI' | 'MSTP' | 'MTLS' | 'MUS' | 'MUSM' | 'NEUR' | 'NSCI' | 'NSG' | 'NURS' | 'OBG' | 'OEH' | 'OMFS' | 'OPER' | 'OPHT' | 'OPRM' | 'ORDN' | 'ORSC' | 'ORTH' | 'OSTC' | 'OTO' | 'OTP' | 'PA' | 'PATH' | 'PCD' | 'PCOL' | 'PCP' | 'PEDO' | 'PEDS' | 'PERF' | 'PERI' | 'PHAR' | 'PHIL' | 'PHTO' | 'PHYS' | 'PNTG' | 'POLI' | 'PORT' | 'PRNT' | 'PROS' | 'PSQF' | 'PSY' | 'PSYC' | 'PTRS' | 'RAD' | 'RADO' | 'RCE' | 'REA' | 'RELS' | 'RHET' | 'RSCI' | 'RSCT' | 'RSMR' | 'RSMS' | 'RSNM' | 'RSP' | 'RSRT' | 'RSTH' | 'SCLP' | 'SIED' | 'SLA' | 'SLAV' | 'SLIS' | 'SOAS' | 'SOC' | 'SPAN' | 'SPST' | 'SRM' | 'SSTP' | 'SSW' | 'STAT' | 'SURG' | 'SWAH' | 'TAPE' | 'TBM' | 'TDSN' | 'THTR' | 'TOX' | 'TR' | 'TRNS' | 'UICB' | 'UIUB' | 'ULIB' | 'URES' | 'URO' | 'URP' | 'WLLC' | 'WRIT';
GenEd: 'ENGIN_CREATIVE' | 'HP' | 'INTERP' | 'INTL_GLOBAL' | 'LIT_VIS_PA' | 'NS' | 'NS_LAB_ONLY' | 'NS_LAB' | 'QFR' | 'RHET_TWO' | 'RHET_SPCH' | 'RHET_WRTNG' | 'SS' | 'VAL_SOC_DIV' | 'FL_1ST' | 'FL_2ND' | 'FL_4TH';
Season: 'SPRING' | 'SUMMER' | 'FALL' | 'WINTER';
Catalog: 'CATALOG';
LeftParen: '(';
RightParen: ')';
LeftBracket: '[';
RightBracket: ']';
Comma: ',';
Dash: '_';
OrderBy: 'ORDER BY';
Limit: 'LIMIT';
And: 'AND';
Or: 'OR';
In: 'IN';
NotIn: 'NOT IN';
Equals: '=';
NotEquals: '!=';
Gt: '>';
GtEq: '>=';
Lt: '<';
LtEq: '<=';
True: 'True';
False: 'False';
Asc: 'ASC';
Desc: 'DESC';
Source: 'Source';
DepartmentSelector: 'Department';
CourseNumberSelector: 'Number';
IsHonorsSelector: 'IsHonors';
GenEdSelector: 'GenEd';
CourseNumber: Digit Digit Digit Digit;
Year: Digit Digit Digit Digit;
fragment Digit: [0-9];
WS:	' ' -> channel(HIDDEN);
