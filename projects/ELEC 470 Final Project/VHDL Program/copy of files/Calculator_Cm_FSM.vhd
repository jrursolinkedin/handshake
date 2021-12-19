library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity Calculator_Cm_FSM is
	port(
		clk : in std_logic;
		echo : in std_logic;
		comparator_out : in std_logic;
		enable_counter_one : out std_logic;
		enable_counter_two : out std_logic;
		reset_counter_one : out std_logic;
		reset_counter_two : out std_logic
	);
end entity;

architecture behave of Calculator_Cm_FSM is

	signal next_state : std_logic_vector(2 downto 0) := (others=>'0');
	signal current_state : std_logic_vector(2 downto 0) := (others=>'0');

begin

	-- Updates "current_state".
	process(clk, echo, next_state)
	begin
		
		if echo = '0' then
			current_state <= (others=>'0');
		elsif rising_edge(clk) then
			current_state <= next_state;
		end if;
	
	end process;
	
	-- Updates output values and "next_state".
	process(current_state, echo, comparator_out)
	begin
	
		case current_state is
			-- State 0:
			when "000" =>
				enable_counter_one <= '0';
				enable_counter_two <= '0';
				reset_counter_one <= '0';
				reset_counter_two <= '0';
				if echo = '1' then
					next_state <= "001";
				else
					next_state <= current_state;
				end if;
			-- State 1:
			when "001" =>
				enable_counter_one <= '0';
				enable_counter_two <= '0';
				reset_counter_one <= '1';
				reset_counter_two <= '1';
				next_state <= "010";
			-- State 2:
			when "010" => 
				enable_counter_one <= '1';
				enable_counter_two <= '0';
				reset_counter_one <= '0';
				reset_counter_two <= '0';
				if comparator_out = '1' then
					next_state <= "011";
				else
					next_state <= current_state; 
				end if;
			-- State 3:
			when "011" =>
				enable_counter_one <= '0';
				enable_counter_two <= '1';
				reset_counter_one <= '1';
				reset_counter_two <= '0';
				next_state <= "010";
			-- Default:
			when others =>
				enable_counter_one <= '0';
				enable_counter_two <= '0';
				reset_counter_one <= '0';
				reset_counter_two <= '0';
		end case;	
	
	end process;

end architecture;