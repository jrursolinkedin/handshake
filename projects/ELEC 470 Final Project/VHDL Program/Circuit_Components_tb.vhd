library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity Circuit_Components_tb is
end entity;

architecture behave of Circuit_Components_tb is 

	-- Component Declaration for the Unit Under Test (UUT).
	component Circuit_Components is
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
			rts : out std_logic
		);
	end component;

	-- Inputs:
	signal clk : std_logic := '0';
	signal rst : std_logic := '0';
	signal echo : std_logic := '0';

 	-- Outputs:
	signal trig : std_logic := '0';
	signal dis_one : std_logic_vector(6 downto 0) := "1111111";
	signal dis_ten : std_logic_vector(6 downto 0) := "1111111";
	signal dis_hundred : std_logic_vector(6 downto 0) := "1111111";
	signal data_ram : std_logic_vector(8 downto 0) := "000000000";
	signal tx : std_logic := '1';
	signal rts : std_logic := '0';

	-- Clock period definitions.
	constant clk_period : time := 20 ns;
	
begin

	-- Instantiate the Unit Under Test (UUT).
	uut : Circuit_Components port map (
		clk => clk,
		rst => rst,
		echo => echo,
		trig => trig,
		dis_one => dis_one,
		dis_ten => dis_ten,
		dis_hundred => dis_hundred,
		data_ram => data_ram,
		tx => tx,
		rts => rts
   );

   -- Clock process definitions.
   clk_process : process
   begin
	
		clk <= '1';
		wait for clk_period/2;
		clk <= '0';
		wait for clk_period/2;
		
   end process;

   data_in_process : process
   begin
		
		echo <= '0';
		rst <= '1';
		wait for 15000 ns;
		echo <= '1';
		rst <= '1';
		wait for 2900000 ns;
		echo <= '0';
		rst <= '1';
		wait for 57085000 ns;
		
		-- 201 cm:
		echo <= '0';
		rst <= '0';
		wait for 15000 ns;
		echo <= '1';
		rst <= '0';
		wait for 11658000 ns;
		echo <= '0';
		rst <= '0';
		wait for 48327000 ns;
		
		-- 50 cm:
		echo <= '0';
		rst <= '0';
		wait for 15000 ns;
		echo <= '1';
		rst <= '0';
		wait for 2900000 ns;
		echo <= '0';
		rst <= '0';
		wait for 57085000 ns;
		
		echo <= '0';
		rst <= '1';
		wait for 15000 ns;
		echo <= '1';
		rst <= '1';
		wait for 2900000 ns;
		echo <= '0';
		rst <= '1';
		wait for 57085000 ns;
		
	end process;

end architecture;