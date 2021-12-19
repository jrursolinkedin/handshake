library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

-- inscape

entity HCSR04 is
	generic(segment : integer:= 7; num_cm : integer:= 9);
	port(
		clk : in std_logic;
		reset : in std_logic;
		echo : in std_logic;
		done : out std_logic;
		trigger : out std_logic;
		display_cm : out std_logic_vector(num_cm-1 downto 0);
		display_one : out std_logic_vector(segment-1 downto 0);
		display_ten : out std_logic_vector(segment-1 downto 0);
		display_hundred : out std_logic_vector(segment-1 downto 0)
	);
end entity;

architecture behave of HCSR04 is

	component Sensor_FSM is
		port(
			clk : in std_logic;
			reset : in std_logic;
			comparator_out : in std_logic;
			done : out std_logic;
			enable_trigger : out std_logic;
			enable_counter : out std_logic;
			reset_counter : out std_logic
	);
	end component;
	
	component Sensor_Counter is
		generic(cycles : integer:= 22);
		port(
			clk : in std_logic;
			reset : in std_logic;
			enable : in std_logic;
			count_cycles : out std_logic_vector(cycles-1 downto 0)
		);
	end component;
	
	component Sensor_Comparator is
		generic(cycles : integer:= 22);
		port(
			count_cycles_in : in std_logic_vector(cycles-1 downto 0);
			reference_one : in std_logic_vector(cycles-1 downto 0);
			reference_two : in std_logic_vector(cycles-1 downto 0);
			comparator_out : out std_logic
		);
	end component;
	
	
	-- helejdjdjkd
	
	component Distance_FSM is
		port(
			clk : in std_logic;
			echo : in std_logic;
			enable_counter : out std_logic;
			reset_counter : out std_logic
		);
	end component;

	component Distance_Counter is
		generic(cycles : integer:= 21);
		port(
			clk : in std_logic;
			reset : in std_logic;
			enable : in std_logic;
			count_cycles : out std_logic_vector(cycles-1 downto 0)
		);
	end component;
	
	component Distance_Calculator is
		generic(cycles : integer:= 21; dist : integer := 4);
		port(
			count : in std_logic_vector(cycles-1 downto 0);
			distance_one : out std_logic_vector(dist-1 downto 0);
			distance_ten : out std_logic_vector(dist-1 downto 0);
			distance_hundred : out std_logic_vector(dist-1 downto 0)
		);
	end component;
	
	component Distance_Decoder is
		generic(dist : integer:= 4; segment : integer := 7);
		port(
			distance_in_one : in std_logic_vector(dist-1 downto 0);
			distance_in_ten : in std_logic_vector(dist-1 downto 0);
			distance_in_hundred : in std_logic_vector(dist-1 downto 0);
			display_out_one : out std_logic_vector(segment-1 downto 0);
			display_out_ten : out std_logic_vector(segment-1 downto 0);
			display_out_hundred : out std_logic_vector(segment-1 downto 0)
		);
	end component;
	
	
	-- jdjjdjdjd
	
	component Calculator_Cm_FSM is
		port(
			clk : in std_logic;
			echo : in std_logic;
			comparator_out : in std_logic;
			enable_counter_one : out std_logic;
			enable_counter_two : out std_logic;
			reset_counter_one : out std_logic;
			reset_counter_two : out std_logic
		);
	end component;
	
	component Calculator_Cm_Counter_One is
		generic(cycles : integer:= 12);
		port(
			clk : in std_logic;
			reset : in std_logic;
			enable : in std_logic;
			count_cycles : out std_logic_vector(cycles-1 downto 0)
		);
	end component;
	
	component Calculator_Cm_Comparator is
		generic(cycles : integer:= 12);
		port(
			count_cycles_in : in std_logic_vector(cycles-1 downto 0);
			reference : in std_logic_vector(cycles-1 downto 0);
			comparator_out : out std_logic
		);
	end component;
	
	component Calculator_Cm_Counter_Two is
		generic(cm : integer:= 9);
		port(
			clk : in std_logic;
			reset : in std_logic;
			enable : in std_logic;
			count_cm : out std_logic_vector(cm-1 downto 0)
		);
	end component;

	
	signal sen_comp_out : std_logic;
	signal sen_enable_cnt : std_logic;
	signal sen_reset_cnt : std_logic;
	signal sen_or_reset : std_logic;
	signal sen_ref_one : std_logic_vector(21 downto 0) := "0000000000000111110100";
	signal sen_ref_two : std_logic_vector(21 downto 0) := "1011011100011011000000";
	signal sen_cnt_cycles : std_logic_vector(21 downto 0);
	
	signal dist_enable_cnt : std_logic;
	signal dist_reset_cnt : std_logic;
	signal dist_cnt_cycles : std_logic_vector(20 downto 0);
	signal dist_one : std_logic_vector(3 downto 0);
	signal dist_ten : std_logic_vector(3 downto 0);
	signal dist_hundred : std_logic_vector(3 downto 0);
	
	signal calc_count_one_reset : std_logic;
	signal calc_count_two_reset : std_logic;
	signal calc_count_one_enable : std_logic;
	signal calc_count_two_enable : std_logic;
	signal calc_comparator_output : std_logic;
	signal calc_count_cycles_output : std_logic_vector(11 downto 0);
	signal calc_ref : std_logic_vector(11 downto 0) := "101101010100";

begin

	instaniate_sensor_fsm : Sensor_FSM port map(
		clk => clk,
		reset => reset,
		comparator_out => sen_comp_out,
		done => done,
		enable_trigger => trigger,
		enable_counter => sen_enable_cnt,
		reset_counter => sen_reset_cnt
	);
	
	sen_or_reset <= (reset or sen_reset_cnt);
	instantiate_sensor_count : Sensor_Counter port map(
		clk => clk,
		reset => sen_or_reset,
		enable => sen_enable_cnt,
		count_cycles => sen_cnt_cycles
	);
	
	instantiate_sensor_compar : Sensor_Comparator port map(
		count_cycles_in => sen_cnt_cycles,
		reference_one => sen_ref_one,
		reference_two => sen_ref_two,
		comparator_out => sen_comp_out
	);
	
	-- dhdhjdjkd
	
	instaniate_dist_fsm : Distance_FSM port map(
		clk => clk,
		echo => echo,
		enable_counter => dist_enable_cnt,
		reset_counter => dist_reset_cnt
	);
	
	instantiate_dist_count : Distance_Counter port map(
		clk => clk,
		reset => dist_reset_cnt,
		enable => dist_enable_cnt,
		count_cycles => dist_cnt_cycles
	);
	
	instantiate_dist_calc : Distance_Calculator port map(
		count => dist_cnt_cycles,
		distance_one => dist_one,
		distance_ten => dist_ten,
		distance_hundred => dist_hundred
	);
	
	instantiate_dist_decoder : Distance_Decoder port map(
		distance_in_one => dist_one,
		distance_in_ten => dist_ten,
		distance_in_hundred => dist_hundred,
		display_out_one => display_one,
		display_out_ten => display_ten,
		display_out_hundred => display_hundred
	);
	
	-- fjdjdjd
	
	instantiate_calc_cm_fsm : Calculator_Cm_FSM port map(
		clk => clk,
		echo => echo,
		comparator_out => calc_comparator_output,
		enable_counter_one => calc_count_one_enable,
		enable_counter_two => calc_count_two_enable,
		reset_counter_one => calc_count_one_reset,
		reset_counter_two => calc_count_two_reset
	);
	
	instantiate_calc_cm_count_one : Calculator_Cm_Counter_One port map(
		clk => clk,
		reset => calc_count_one_reset,
		enable => calc_count_one_enable,
		count_cycles => calc_count_cycles_output
	);
	
	instantiate_calc_cm_compar : Calculator_Cm_Comparator port map(
		count_cycles_in => calc_count_cycles_output,
		reference => calc_ref,
		comparator_out => calc_comparator_output
	);
	
	instantiate_calc_cm_count_two : Calculator_Cm_Counter_Two port map(
		clk => clk,
		reset => calc_count_two_reset,
		enable => calc_count_two_enable,
		count_cm => display_cm
	);
	
end architecture;