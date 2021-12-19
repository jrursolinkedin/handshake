LIBRARY IEEE;
USE IEEE.std_logic_1164.all;
USE IEEE.numeric_std.all;

ENTITY OneStep_FSM IS 
	 PORT(
	      clk      : in std_logic;
			rst      : in std_logic;
			Comp_out : in std_logic;
			count_rst_fsm: out std_logic;
			phase_a  : out std_logic;
			phase_b  : out std_logic;
			phase_c  : out std_logic;
			phase_d  : out std_logic
			
	     );
END ENTITY;

ARCHITECTURE One_StepBehave OF OneStep_FSM IS 
SIGNAL next_state, current_state : std_logic_vector(2 downto 0) := (others=>'0');
--SIGNAL sig_a, sig_b, sig_c, sig_d, sig_e : std_logic_vector( 2 downto 0);

BEGIN

Process(current_state, Comp_out, rst)
Begin

CASE current_state IS

WHEN "000" =>
	phase_a <='0';
	phase_b <='0';
	phase_c <='0';
	phase_d <='0';
	
	if comp_out = '1' then
		next_state <= "001";
	else 
		next_state <= current_state;
		
		end if;
WHEN "001" =>
	phase_a <='1';
	phase_b <='0';
	phase_c <='0';
	phase_d <='0';
   
	if comp_out = '1' then
		next_state <= "010";
		count_rst_fsm <= '1';
	else 
		next_state <= current_state;
		count_rst_fsm <= '0';
		end if;	
	
WHEN "010" =>
	phase_a <='0';
	phase_b <='1';
	phase_c <='0';
	phase_d <='0';
	
		if comp_out = '1' then
		next_state <= "011";
				count_rst_fsm <= '1';

	else 
		next_state <= current_state;
				count_rst_fsm <= '0';

		end if;
		
WHEN "011" =>
	phase_a <='0';
	phase_b <='0';
	phase_c <='1';
	phase_d <='0';
		
		if comp_out = '1' then
		next_state <= "100";
						count_rst_fsm <= '1';

	else 
		next_state <= current_state;
						count_rst_fsm <= '0';

		end if;
	
WHEN "100" =>
	phase_a <='0';
	phase_b <='0';
	phase_c <='0';
	phase_d <='1';

	if comp_out = '1' then
		next_state <= "000";
								count_rst_fsm <= '1';

	else 
		next_state <= current_state;
									count_rst_fsm <= '0';

	end if;
	
WHEN others =>
	phase_a <='0';
	phase_b <='0';
	phase_c <='0';
	phase_d <='0';
     
	  
	  
END CASE;

End Process;

-- current state registor
--current_state <= current_state + 1;
Process(clk, rst, current_state)
Begin
	if rst = '1' then
		current_state <= (others=> '0');
	elsif rising_edge(clk) then
		current_state <= next_state;
	end if;
	end process;
	

end Architecture;