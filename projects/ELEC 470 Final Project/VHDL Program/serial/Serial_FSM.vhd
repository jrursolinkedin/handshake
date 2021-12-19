library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity Serial_FSM is
	generic(num_dist : integer:= 9);
	port(
		clk : in std_logic;
		reset : in std_logic;
		sensor_done : in std_logic;
		comparator_out : in std_logic;
		data_in : in std_logic_vector(num_dist-1 downto 0);
		tx_port : out std_logic;
		rts_port : out std_logic;
		enable_counter : out std_logic;
		reset_counter : out std_logic
	);
end entity;

architecture behave of Serial_FSM is

	signal current_state : std_logic_vector(4 downto 0):= (others=>'0');
	signal next_state : std_logic_vector(4 downto 0):= (others=>'0');

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
			when "00000" =>
				tx_port <= '1';
				rts_port <= '0';
				enable_counter <= '0';
				reset_counter <= '0';
				if sensor_done = '1' then
					next_state <= "00001";
				else
					next_state <= "00000";
				end if;
			-- State 1:
			when "00001" =>
				tx_port <= '0';
				rts_port <= '0';
				enable_counter <= '1';
				reset_counter <= '0';
				if comparator_out = '1' then
					next_state <= "00010";
				else
					next_state <= "00001";
				end if;
			-- State 2:
			when "00010" =>
				tx_port <= '0';
				rts_port <= '0';
				enable_counter <= '0';
				reset_counter <= '1';
				next_state <= "00011";
			-- State 3:
			when "00011" =>
				tx_port <= data_in(0);
				rts_port <= '1';
				enable_counter <= '1';
				reset_counter <= '0';
				if comparator_out = '1' then
					next_state <= "00100";
				else
					next_state <= "00011";
				end if;
			-- State 4:
			when "00100" =>
				tx_port <= '0';
				rts_port <= '0';
				enable_counter <= '0';
				reset_counter <= '1';
				next_state <= "00101";
			-- State 5:
			when "00101" =>
				tx_port <= data_in(1);
				rts_port <= '1';
				enable_counter <= '1';
				reset_counter <= '0';
				if comparator_out = '1' then
					next_state <= "00110";
				else
					next_state <= "00101";
				end if;
			-- State 6:
			when "00110" =>
				tx_port <= '0';
				rts_port <= '0';
				enable_counter <= '0';
				reset_counter <= '1';
				next_state <= "00111";
			-- State 7:
			when "00111" =>
				tx_port <= data_in(2);
				rts_port <= '1';
				enable_counter <= '1';
				reset_counter <= '0';
				if comparator_out = '1' then
					next_state <= "01000";
				else
					next_state <= "00111";
				end if;
			-- State 8:
			when "01000" =>
				tx_port <= '0';
				rts_port <= '0';
				enable_counter <= '0';
				reset_counter <= '1';
				next_state <= "01001";
			-- State 9:
			when "01001" =>
				tx_port <= data_in(3);
				rts_port <= '1';
				enable_counter <= '1';
				reset_counter <= '0';
				if comparator_out = '1' then
					next_state <= "01010";
				else
					next_state <= "01001";
				end if;
			-- State 10:
			when "01010" =>
				tx_port <= '0';
				rts_port <= '0';
				enable_counter <= '0';
				reset_counter <= '1';
				next_state <= "01011";
			-- State 11:
			when "01011" =>
				tx_port <= data_in(4);
				rts_port <= '1';
				enable_counter <= '1';
				reset_counter <= '0';
				if comparator_out = '1' then
					next_state <= "01100";
				else
					next_state <= "01011";
				end if;
			-- State 12:
			when "01100" =>
				tx_port <= '0';
				rts_port <= '0';
				enable_counter <= '0';
				reset_counter <= '1';
				next_state <= "01101";
			-- State 13:
			when "01101" =>
				tx_port <= data_in(5);
				rts_port <= '1';
				enable_counter <= '1';
				reset_counter <= '0';
				if comparator_out = '1' then
					next_state <= "01110";
				else
					next_state <= "01101";
				end if;
			-- State 14:
			when "01110" =>
				tx_port <= '0';
				rts_port <= '0';
				enable_counter <= '0';
				reset_counter <= '1';
				next_state <= "01111";
			-- State 15:
			when "01111" =>
				tx_port <= data_in(6);
				rts_port <= '1';
				enable_counter <= '1';
				reset_counter <= '0';
				if comparator_out = '1' then
					next_state <= "10000";
				else
					next_state <= "01111";
				end if;
			-- State 16:
			when "10000" =>
				tx_port <= '0';
				rts_port <= '0';
				enable_counter <= '0';
				reset_counter <= '1';
				next_state <= "10001";
			-- State 17:
			when "10001" =>
				tx_port <= data_in(7);
				rts_port <= '1';
				enable_counter <= '1';
				reset_counter <= '0';
				if comparator_out = '1' then
					next_state <= "10010";
				else
					next_state <= "10001";
				end if;
			-- State 18:
			when "10010" =>
				tx_port <= '0';
				rts_port <= '0';
				enable_counter <= '0';
				reset_counter <= '1';
				next_state <= "00000";
			-- Default State:
			when others =>
				tx_port <= '1';
				rts_port <= '0';
				enable_counter <= '0';
				reset_counter <= '0';
				next_state <= "00000";
		end case;
	
	end process;

end architecture;