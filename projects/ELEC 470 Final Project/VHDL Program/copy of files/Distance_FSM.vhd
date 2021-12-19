library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity Distance_FSM is
	port(
		clk : in std_logic;
		echo : in std_logic;
		enable_counter : out std_logic;
		reset_counter : out std_logic
	);
end entity;

architecture behave of Distance_FSM is

	signal next_state : std_logic_vector(2 downto 0) := (others=>'0');
	signal current_state : std_logic_vector(2 downto 0) := (others=>'0');

begin

	-- Updates "current_state".
	process(clk,echo)
	begin
		
		if echo = '0' then
			current_state <= (others=>'0');
		elsif rising_edge(clk) then
			current_state <= next_state;
		end if;
	
	end process;
	
	-- Updates output values and "next_state".
	process(current_state, echo)
	begin
	
		case current_state is
			-- State 0:
			when "000" =>
				enable_counter <= '0';
				reset_counter <= '0';
				if echo = '1' then
					next_state <= "001";
				else
					next_state <= current_state;
				end if;
			-- State 1:
			when "001" =>
				enable_counter <= '0';
				reset_counter <= '1';
				next_state <= "010";
			-- State 2:
			when "010" => 
				enable_counter <= '1';
				reset_counter <= '0';
				if echo = '0' then
					next_state <= "000";
				else
					next_state <= current_state; 
				end if;
			-- Other:
			when others =>
				enable_counter <= '0';
				reset_counter <= '0';
		end case;	
	
	end process;

end architecture;