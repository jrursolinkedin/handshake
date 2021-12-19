library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity Circuit_Components is
	generic(seven_seg : integer:= 7; measurement : integer:= 9);
	port(
		clk : in std_logic;
		rst : in std_logic;
		echo : in std_logic;
		trig : out std_logic;
		dis_one : out std_logic_vector(seven_seg-1 downto 0);
		dis_ten : out std_logic_vector(seven_seg-1 downto 0);
		dis_hundred : out std_logic_vector(seven_seg-1 downto 0);
		data_ram : out std_logic_vector(measurement-1 downto 0);
		tx : out std_logic;
		rts : out std_logic;
		p_one : out std_logic;
		p_two : out std_logic;
		p_three : out std_logic;
		p_four : out std_logic
	);
end entity;

architecture behave of Circuit_Components is

	component HCSR04 is
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
	end component;
	
	component Sensor_RAM is
		generic(measurement : integer:= 9);
		port(
			clk : in std_logic;
			reset : in std_logic;
			done_in : in std_logic;
			data_in : in std_logic_vector(measurement-1 downto 0);
			data_out : out std_logic_vector(measurement-1 downto 0)
		);
	end component;
	
	component Sensor_Serial is
		generic(measurement : integer:= 9);
		port(
			clk : in std_logic;
			reset : in std_logic;
			data_in : in std_logic_vector(measurement-1 downto 0);
			tx_port_out : out std_logic;
			rts_port_out : out std_logic
		);
	end component;	
	
	component Stepper_Motor is 
		generic(n : integer := 25);
		PORT(
			clk : in std_logic;
			rst : in std_logic;
			phase_a : out std_logic;
			phase_b : out std_logic;
			phase_c : out std_logic;
			phase_d : out std_logic
	     );
	end component;
	
	signal done_sig : std_logic;
	signal cm_measurement : std_logic_vector(8 downto 0);
	signal copy_cm_measurement : std_logic_vector(8 downto 0);
	
	
begin

	instantiate_hcsr04 : HCSR04 port map(
		clk => clk,
		reset => rst,
		echo => echo,
		done => done_sig,
		trigger => trig,
		display_cm => cm_measurement,
		display_one => dis_one,
		display_ten => dis_ten,
		display_hundred => dis_hundred 
	);
	
	-- Flip Flop...
	process(done_sig)
	begin
	
		if done_sig = '1' then
			copy_cm_measurement <= cm_measurement;
		end if;
		
	end process;
	
	instantiate_sensor_ram : Sensor_RAM port map(
		clk => clk,
		reset => rst,
		done_in => done_sig,
		data_in => copy_cm_measurement,
		data_out => data_ram
	);
	
	instantiate_sensor_serial : Sensor_Serial port map(
		clk => clk,
		reset => rst,
		data_in => copy_cm_measurement,
		tx_port_out => tx,
		rts_port_out => rts
	);
	
	instantiate_motor : Stepper_Motor port map(
		clk => clk,
		rst => rst,
		phase_a => p_one,
		phase_b => p_two,
		phase_d => p_three,
		phase_c => p_four
	);

end architecture;