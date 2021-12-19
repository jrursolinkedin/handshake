LIBRARY IEEE;
USE IEEE.std_logic_1164.all;

ENTITY Stepper_Motor IS 
    GENERIC( n : integer := 25);
	 PORT(
	      clk     : in std_logic;
			rst     : in std_logic;
			phase_a  : out std_logic;
			phase_b  : out std_logic;
			phase_c  : out std_logic;
			phase_d  : out std_logic
	     );
END Stepper_Motor;

ARCHITECTURE OneStepBehave OF Stepper_Motor IS 

COMPONENT COUNTER IS 
    GENERIC( n : integer := 25);
	 PORT(
	      clk : in std_logic;
			rst : in std_logic;
			Cntr_En  : in std_logic;
			cnt : out std_logic_vector(n-1 downto 0)
			
	     );
END COMPONENT;

COMPONENT Comparator IS 
    GENERIC( n : integer := 25);
	 PORT(
	      in_value : in std_logic_vector(n-1 downto 0);
			Ref      : in std_logic_vector(n-1 downto 0);
			Comp_out : out std_logic
			
	     );
END COMPONENT;

COMPONENT OneStep_FSM IS 
	 PORT(
	      clk      : in std_logic;
			rst      : in std_logic;
			Comp_out : in std_logic;
			phase_a  : out std_logic;
			phase_b  : out std_logic;
			phase_c  : out std_logic;
			phase_d  : out std_logic
			
	     );
END COMPONENT;

--Component OneStep IS 
  --  GENERIC( n : integer := 25);
--	 PORT(
--	      clk : in std_logic;
--			rst : in std_logic;
--			OneStep : out std_logic
--	     );
--END component;

-- DIR instead of cntr_rst
-- signals

signal cnt 		    : std_logic_vector(n-1 downto 0);
signal Comp_out    : std_logic;
signal Ref         : std_logic_vector(24 downto 0);
signal Cntr_En     : std_logic;
signal count_rst   : std_logic;
--signal phase_a_out     : std_logic;
--signal phase_b_out     : std_logic;
--signal phase_c_out     : std_logic;
--signal phase_d_out     : std_logic;
BEGIN

--globalreset <= '0';
count_rst <= rst;
Ref       <= "1011111010111100001000000";
--Ref       <= "0000000000111100001000000";
Counter1    : Counter Generic map(n) port map( clk => clk,
                                                rst => count_rst, 
																Cntr_En => '1', 
																cnt => cnt);
																
Comparator1 : Comparator Generic map(n) port map( Ref => Ref, 
																	in_value => cnt, 
																	Comp_out => Comp_out);
																	
FSM1        : OneStep_FSM port map(clk => clk, 
												rst=> rst, 
												comp_out => comp_out, 
												phase_a => phase_a,
												phase_b => phase_b,
												phase_c => phase_c,
												phase_d => phase_d
												);
										

												
--OneStep1 : OneStep generic map(n) port map(
 --                                           clk => clk,
 --														  rst => rst,
 --														  OneStep => One_Step);										

END Architecture;