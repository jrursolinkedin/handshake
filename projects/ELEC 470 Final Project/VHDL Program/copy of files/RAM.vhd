library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;
 -- Imports "conv_integer" function.
use ieee.std_logic_unsigned.all;

entity RAM is
	generic(num_dist : integer:= 9; num_slots : integer:= 8);
	port(
		data_in : in std_logic_vector(num_dist-1 downto 0);
		address_in : in std_logic_vector(num_slots-1 downto 0);
		-- Enable the "read" and "write" features of RAM.
		write_in : in std_logic;
		read_in : in std_logic;
		data_out : out std_logic_vector(num_dist-1 downto 0)
	);
end entity;

architecture behave of RAM is

	-- Basically, "memory" is just an array of size 256 that hold 
	-- all the loaded distance values (in vector of 8 elements).
	type memory_type is array(255 downto 0) of std_logic_vector(num_dist-1 downto 0);
	signal memory : memory_type;
	-- signal memory : memory_type := (others => (others => '0'));
	signal data_out_signal : std_logic_vector(num_dist-1 downto 0) := (others=>'0'); 

begin

	-- Updates "data_out".
	data_out <= data_out_signal;

	-- Determines the output value, "data_out".
	process(address_in, write_in, read_in)
	begin
	
		-- Checks whether "write" setting is enabled.
		if (write_in = '1') and (read_in = '0') then
			memory(conv_integer(address_in)) <= data_in;
		-- Checks whether "read" setting is enabled.
		elsif (write_in = '0') and (read_in = '1') then
			data_out_signal <= memory(conv_integer(address_in));
		-- Else, the default value is set to high inpedence.
		else
			data_out_signal <= data_out_signal;
		end if;
	
	end process;

end architecture;