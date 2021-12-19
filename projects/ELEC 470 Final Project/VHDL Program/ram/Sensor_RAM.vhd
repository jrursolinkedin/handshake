library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity Sensor_RAM is
	generic(measurement : integer:= 9);
	port(
		clk : in std_logic;
		reset : in std_logic;
		done_in : in std_logic;
		data_in : in std_logic_vector(measurement-1 downto 0);
		data_out : out std_logic_vector(measurement-1 downto 0)
	);
end entity;

architecture behave of Sensor_RAM is

	component RAM_FSM is
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
	end component;
	
	component RAM_Counter is
		generic(cnt : integer:= 8);
		port(
			clk : in std_logic;
			reset : in std_logic;
			enable : in std_logic;
			count : out std_logic_vector(cnt-1 downto 0)
		);
	end component;
	
	component RAM_Comparator is
		generic(cnt : integer:= 8);
		port(
			count_in : in std_logic_vector(cnt-1 downto 0);
			reference : in std_logic_vector(cnt-1 downto 0);
			comparator_out : out std_logic
		);
	end component;
	
	component RAM is
		generic(num_dist : integer:= 9; num_slots : integer:= 8);
		port(
			data_in : in std_logic_vector(num_dist-1 downto 0);
			address_in : in std_logic_vector(num_slots-1 downto 0);
			write_in : in std_logic;
			read_in : in std_logic;
			data_out : out std_logic_vector(num_dist-1 downto 0)
		);
	end component;
	
	signal comp_out : std_logic;
	signal wrt : std_logic;
	signal rd : std_logic;
	signal en_count : std_logic;
	signal rst_count : std_logic;
	signal counter_out : std_logic_vector(7 downto 0);
	signal ref : std_logic_vector(7 downto 0) := "11111111";

	

begin

	instaniate_ram_fsm : RAM_FSM port map(
		clk => clk,
		reset => reset,
		sensor_done => done_in,
		comparator_out => comp_out,
		write_out => wrt,
		read_out => rd,
		enable_counter => en_count,
		reset_counter => rst_count
	);
	
	instantiate_ram_count : RAM_Counter port map(
		clk => clk,
		reset => rst_count,
		enable => en_count,
		count => counter_out
	);
	
	instantiate_ram_comp : RAM_Comparator port map(
		count_in => counter_out,
		reference => ref,
		comparator_out => comp_out
	);
	
	instaniate_ram : RAM port map(
		data_in => data_in,
		address_in => counter_out, 
		write_in => wrt,
		read_in => rd,
		data_out => data_out
	);

end architecture;