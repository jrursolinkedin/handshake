library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity Sensor_Serial is
	generic(measurement : integer:= 9);
	port(
		clk : in std_logic;
		reset : in std_logic;
		data_in : in std_logic_vector(measurement-1 downto 0);
		tx_port_out : out std_logic;
		rts_port_out : out std_logic
	);
end entity;

architecture behave of Sensor_Serial is

	component Serial_FSM is
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
	end component;
	
	component Serial_Counter is
		generic(cnt : integer:= 13);
		port(
			clk : in std_logic;
			reset : in std_logic;
			enable : in std_logic;
			count : out std_logic_vector(cnt-1 downto 0)
		);
	end component;
	
	component Serial_Comparator is
		generic(cnt : integer:= 13);
		port(
			count_in : in std_logic_vector(cnt-1 downto 0);
			reference : in std_logic_vector(cnt-1 downto 0);
			comparator_out : out std_logic
		);
	end component;
	
	signal comp_out : std_logic;
	signal en_count : std_logic;
	signal rst_count : std_logic;
	signal count_out : std_logic_vector(12 downto 0);
	-- Baud Rate = 9600 bits per second
	-- Clk Speed = 50 MHz = 2.0E-8
	-- So, 1 bit (# cycles or ref) = ((1/9600)/2.0E-8) = 5208.33 = "5209 cycles"
	signal ref : std_logic_vector(12 downto 0) := "1010001011001";
	
	signal q, str_comp_out, cnt_rst : std_logic;
	signal strcnt : std_logic_vector(24 downto 0);

begin

	instaniate_serial_fsm : Serial_FSM port map(
		clk => clk,
		reset => reset,
		sensor_done => q,
		comparator_out => comp_out,
		data_in => data_in,
		tx_port => tx_port_out,
		rts_port => rts_port_out,
		enable_counter => en_count,
		reset_counter => rst_count
	);
	
	instantiate_serial_count : Serial_Counter port map(
		clk => clk,
		reset => rst_count,
		enable => en_count,
		count => count_out
	);
	
	instantiate_serial_comp : Serial_Comparator port map(
		count_in => count_out,
		reference => ref,
		comparator_out => comp_out
	);
	
	process(clk,reset)
	begin
	
		if reset = '1' then
			q <= '0';
		elsif rising_edge(clk) then
			q <= str_comp_out;
		end if;
		
	end process;

	StartComp : Serial_Comparator generic map(25) port map(
		count_in => strcnt,
		reference => "0011000000000000000000000",
		comparator_out => str_comp_out
	);
	
	cnt_rst <= reset or q;
	StartCounter: Serial_Counter generic map (25) port map (
		clk=> clk,
		reset=> cnt_rst,
		enable => '1',
		count => strcnt
	);				

end architecture;