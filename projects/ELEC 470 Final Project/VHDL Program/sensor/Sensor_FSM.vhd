library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity Sensor_FSM is
	port(
		clk : in std_logic;
		reset : in std_logic;
		comparator_out : in std_logic;
		done : out std_logic;
		enable_trigger : out std_logic;
		enable_counter : out std_logic;
		reset_counter : out std_logic
	);
end entity;

architecture behave of Sensor_FSM is

	signal next_state : std_logic_vector(2 downto 0) := (others=>'0');
	signal current_state : std_logic_vector(2 downto 0) := (others=>'0');

begin

	-- Updates "current_state".
	process(clk, reset)
	begin
		if reset = '1' then
			current_state <= (others=>'0');
		elsif rising_edge(clk) then
			current_state <= next_state;
		end if;
	
	end process;
	
	-- Updates output values and "next_state".
	process(current_state, comparator_out)
	begin
	
		case current_state is
			-- State 0:
			when "000" =>
				enable_trigger <= '0';
				done <= '0';
				reset_counter <= '0';
				enable_counter <= '0';
				next_state <= "001";
			-- State 1:
			when "001" =>
				enable_trigger <= '1';
				done <= '0';
				reset_counter <= '0';
				enable_counter <= '1';
				if comparator_out = '1' then
					next_state <= "010";
				else
					next_state <= current_state;
				end if;
			-- State 2:
			when "010" =>
				enable_trigger <= '0';
				done <= '0';
				reset_counter <= '0';
				enable_counter <= '1';
				if comparator_out = '1' then
					next_state <= "011";
				else
					next_state <= current_state;
				end if;
			-- State 3: 
			when "011" =>
				enable_trigger <= '0';
				done <= '1';
				reset_counter <= '1';
				enable_counter <= '0';
				next_state <= "000";
			when others =>
				enable_trigger <= '0';
				done <= '0';
				enable_counter <= '0';
				reset_counter <= '0';
		end case;	
	
	end process;

end architecture;