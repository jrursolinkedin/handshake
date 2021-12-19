library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity RAM_FSM is
	generic(num_dist : integer:= 9);
	port(
		clk : in std_logic;
		reset : in std_logic;
		sensor_done : in std_logic;
		comparator_out : in std_logic;
		write_out : out std_logic;
		read_out : out std_logic;
		enable_counter : out std_logic;
		reset_counter : out std_logic
	);
end entity;

architecture behave of RAM_FSM is

	signal current_state : std_logic_vector(2 downto 0):= (others=>'0');
	signal next_state : std_logic_vector(2 downto 0):= (others=>'0');

begin

	-- Updates the "current_state" signal.
	process(clk, reset)
	begin
	
		if reset = '1' then
			current_state <= (others=>'0');
		elsif rising_edge(clk) then
			current_state <= next_state;
		end if;
	
	end process;
	
	-- Updates the output values.
	process(current_state, sensor_done, comparator_out)
	begin
	
		case current_state is
			-- State 0:
			when "000" =>
				write_out <= '0';
				read_out <= '0';
				enable_counter <= '0';
				reset_counter <= '0';
				if sensor_done = '1' then
					next_state <= "001";
				else
					next_state <= "000";
				end if;
			-- State 1:
			when "001" =>
				write_out <= '1';
				read_out <= '0';
				enable_counter <= '0';
				reset_counter <= '0';
				next_state <= "010";
			-- State 2:
			when "010" =>
				write_out <= '0';
				read_out <= '1';
				enable_counter <= '0';
				reset_counter <= '0';
				next_state <= "011";
			-- State 3:
			when "011" =>
				write_out <= '0';
				read_out <= '0';
				enable_counter <= '1';
				reset_counter <= '0';
				next_state <= "100";
			-- State 4:
			when "100" =>
				write_out <= '0';
				read_out <= '0';
				enable_counter <= '0';
				reset_counter <= '0';
				if comparator_out = '1' then
					next_state <= "101";
				else
					next_state <= "000";
				end if;
			-- State 5:
			when "101" =>
				write_out <= '0';
				read_out <= '0';
				enable_counter <= '0';
				reset_counter <= '1';
				next_state <= "000";
			-- Default State:
			when others =>
				write_out <= '0';
				read_out <= '0';
				enable_counter <= '0';
				reset_counter <= '0';	
		end case;
	
	end process;

end architecture;